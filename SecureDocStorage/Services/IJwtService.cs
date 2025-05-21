namespace SecureDocStorage.Services
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string username); // ✅ No 'public', no body
    }
}
