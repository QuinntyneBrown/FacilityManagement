namespace FacilityManagement.SharedKernel.Identity
{
    public interface IPasswordHasher
    {
        string HashPassword(Byte[] salt, string password);
    }
}
