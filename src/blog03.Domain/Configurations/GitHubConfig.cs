namespace blog03.Configurations
{
    public static class GitHubConfig
    {
        public static string API_Authorize = "http://github.com/login/oauth/authorize";
        public static string API_AccessToken = "https://github.com/login/oauth/access_token";
        public static string API_User = "https://api.github.com/user";
        public static int UserId = AppSettings.GitHub.UserId;
        public static string Client_ID = AppSettings.GitHub.Client_ID;
        public static string Client_Secret = AppSettings.GitHub.Client_Secret;
        public static string Redirect_Uri = AppSettings.GitHub.Redirect_Uri;
        public static string ApplicationName = AppSettings.GitHub.ApplicationName;
    }
}
