using blog03.Configurations;

namespace blog03.ToolKits.GitHub
{
    public class AccessTokenRequest
    {
        public string Client_ID = GitHubConfig.Client_ID;
        public string Client_Secret = GitHubConfig.Client_Secret;
        public string Code { get; set; }
        public string Redirect_Uri = GitHubConfig.Redirect_Uri;
        public string State { get; set; }
    }
}
