namespace TerraAssistance.ProblemManagement.Application.Security;

using System.Security.Claims;

public class UserIdentity : ClaimsIdentity
{
    public UserIdentity(ClaimsIdentity user)
        : base(user)
    {
    }

    public int Id
    {
        get
        {
            var value = FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (value is null)
                throw new InvalidOperationException("User ID claim not found.");

            return int.Parse(value);
        }
    }
}