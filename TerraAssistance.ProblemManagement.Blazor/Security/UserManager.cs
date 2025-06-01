namespace TerraAssistance.ProblemManagement.Blazor.Security;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TerraAssistance.ProblemManagement.Blazor.Data;

public class UserManager : UserManager<ApplicationUser>
{
    public UserManager(
        IUserStore<ApplicationUser> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<ApplicationUser> passwordHasher,
        IEnumerable<IUserValidator<ApplicationUser>> userValidators,
        IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManager> logger)
                : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }
}