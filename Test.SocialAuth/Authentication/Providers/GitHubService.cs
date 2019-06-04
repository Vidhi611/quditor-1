namespace Test.SocialAuth.Authentication.Providers
{
    using System.Security.Claims;
    using Test.SocialAuth.Contracts.Models;

    public class GitHubService : IGitHubService
    {
        private readonly string nameidentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        private readonly string username = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        private readonly string name = "urn:github:name";
        private readonly string githuburl = "urn:github:url";

        public User BuildUserFromClaims(ClaimsPrincipal claimsPrincipal)
        {
            return new User()
            {
                IdentityId = claimsPrincipal.FindFirstValue(nameidentifier),
                UserName = claimsPrincipal.FindFirstValue(username),
                FirstName = claimsPrincipal.FindFirstValue(name),
                Provider = Provider.GitHub,
                GitHubUrl = claimsPrincipal.FindFirstValue(githuburl)
            };
        }
    }
}
