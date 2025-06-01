namespace TerraAssistance.ProblemManagement.Blazor.Security;

using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using TerraAssistance.ProblemManagement.Application.Security;

public class UserIdentityAccessor : IUserIdentityAccessor
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public UserIdentityAccessor(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<UserIdentity?> TryGetUserIdentityAsync(CancellationToken cancellationToken)
    {
        var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();

        return authenticationState.User.Identity?.IsAuthenticated == true
            ? new UserIdentity(authenticationState.User.Identities.First())
            : null;
    }
}