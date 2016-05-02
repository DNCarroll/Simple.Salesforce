using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Simple.Salesforce
{
    public static class Common
    {
        public static Uri FormatUrl(string resourceName, string instanceUrl, string apiVersion)
        {
            if (string.IsNullOrEmpty(resourceName)) throw new ArgumentNullException("resourceName");
            if (string.IsNullOrEmpty(instanceUrl)) throw new ArgumentNullException("instanceUrl");
            if (string.IsNullOrEmpty(apiVersion)) throw new ArgumentNullException("apiVersion");

            if (resourceName.StartsWith("/services/data", StringComparison.CurrentCultureIgnoreCase))
            {
                return new Uri(new Uri(instanceUrl), resourceName);
            }

            return new Uri(new Uri(instanceUrl), string.Format("/services/data/{0}/{1}", apiVersion, resourceName));
        }

        public static string FormatRefreshTokenUrl(
            string tokenRefreshUrl,
            string clientId,
            string refreshToken,
            string clientSecret = "")
        {
            if (tokenRefreshUrl == null) throw new ArgumentNullException("tokenRefreshUrl");
            if (clientId == null) throw new ArgumentNullException("clientId");
            if (refreshToken == null) throw new ArgumentNullException("refreshToken");

            var clientSecretQuerystring = "";
            if (!string.IsNullOrEmpty(clientSecret))
            {
                clientSecretQuerystring = string.Format("&client_secret={0}", clientSecret);
            }

            var url =
            string.Format(
                "{0}?grant_type=refresh_token&client_id={1}{2}&refresh_token={3}",
                tokenRefreshUrl,
                clientId,
                clientSecretQuerystring,
                refreshToken);

            return url;
        }


        public async static Task<ForceClient> ForceClient() {
            var auth = await AuthenticationClient();
            var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
            return client;
        }

        public async static Task<AuthenticationClient> AuthenticationClient() {
            var auth = new AuthenticationClient();
            await auth.UsernamePasswordAsync(Configuration.SalesforceClientId, 
                                             Configuration.SalesforceSecret, 
                                             Configuration.SalesforceUsername, 
                                             Configuration.SalesforcePassword, 
                                             Configuration.SalesforceEndpoint);
            return auth;
        }
    }
}
