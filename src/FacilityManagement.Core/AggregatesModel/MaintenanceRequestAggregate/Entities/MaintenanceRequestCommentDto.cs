namespace FacilityManagement.Core
{
    public class MaintenanceRequestCommentDto
    {
        public Guid? MaintenanceRequestCommentId { get; set; }
        public Guid? MaintenanceRequestId { get; set; }
        public string? Body { get; set; }
        public DateTime? Created { get; set; } = DateTime.UtcNow;
        public Guid? CreatedById { get; set; }
    }
}
