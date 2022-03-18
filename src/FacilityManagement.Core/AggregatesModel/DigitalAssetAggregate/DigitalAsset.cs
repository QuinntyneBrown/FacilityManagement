using System;

namespace FacilityManagement.Core
{
    public class DigitalAsset
    {
        public DigitalAssetId DigitalAssetId { get; set; }  = new DigitalAssetId(Guid.NewGuid());
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
    }
}
