using LoanManagement.Model;

namespace LoanManagement.Service
{
    public interface ITokenGenerator
    {
        string GenerateJSONWebToken(User user);
    }
}
