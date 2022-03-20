using FacilityManagement.Core.Interfaces;
using FacilityManagement.SharedKernel.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System.Drawing;

namespace FacilityManagement.Core
{
    public class UploadDigitalAssetRequest : IRequest<UploadDigitalAssetResponse> { }

    public class UploadDigitalAssetResponse
    {
        public List<Guid> DigitalAssetIds { get; set; }
    }

    public class UploadDigitalAssetHandler : IRequestHandler<UploadDigitalAssetRequest, UploadDigitalAssetResponse>
    {
        public IFacilityManagementDbContext _context { get; set; }
        public IHttpContextAccessor _httpContextAccessor { get; set; }
        public UploadDigitalAssetHandler(IFacilityManagementDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UploadDigitalAssetResponse> Handle(UploadDigitalAssetRequest request, CancellationToken cancellationToken)
        {

            var httpContext = _httpContextAccessor.HttpContext;
            var defaultFormOptions = new FormOptions();
            var digitalAssets = new List<DigitalAsset>();

            if (!MultipartRequestHelper.IsMultipartContentType(httpContext.Request.ContentType))
                throw new Exception($"Expected a multipart request, but got {httpContext.Request.ContentType}");

            var mediaTypeHeaderValue = MediaTypeHeaderValue.Parse(httpContext.Request.ContentType);

            var boundary = MultipartRequestHelper.GetBoundary(
                mediaTypeHeaderValue,
                defaultFormOptions.MultipartBoundaryLengthLimit);

            var reader = new MultipartReader(boundary, httpContext.Request.Body);

            var section = await reader.ReadNextSectionAsync();

            while (section != null)
            {

                var digitalAsset = new DigitalAsset();

                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out ContentDispositionHeaderValue contentDisposition);

                if (hasContentDispositionHeader)
                {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                    {
                        using (var targetStream = new MemoryStream())
                        {
                            await section.Body.CopyToAsync(targetStream);
                            var name = $"{contentDisposition.FileName}".Trim(new char[] { '"' }).Replace("&", "and");

                            digitalAsset = _context.DigitalAssets.SingleOrDefault(x => x.Name == name);

                            if (digitalAsset == null)
                            {
                                digitalAsset = new DigitalAsset();
                                digitalAsset.Name = name;
                                _context.DigitalAssets.Add(digitalAsset);
                            }

                            digitalAsset.Bytes = StreamHelper.ReadToEnd(targetStream);
                            digitalAsset.ContentType = section.ContentType;
                        }

                        try
                        {
                            using (var image = Image.FromStream(new MemoryStream(digitalAsset.Bytes)))
                            {
                                digitalAsset.Height = image.PhysicalDimension.Height;
                                digitalAsset.Width = image.PhysicalDimension.Width;
                            }
                        }
                        catch (Exception)
                        {

                        }

                    }
                }

                digitalAssets.Add(digitalAsset);

                section = await reader.ReadNextSectionAsync();
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new UploadDigitalAssetResponse()
            {
                DigitalAssetIds = digitalAssets.Select(x => x.DigitalAssetId.Value).ToList()
            };
        }
    }

}
