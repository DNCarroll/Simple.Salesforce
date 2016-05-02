using System.Configuration;

namespace Simple.Salesforce {
    public static class Configuration {
        private static string _SalesForceClientID;
        public static string SalesforceClientId {
            get {

                if (_SalesForceClientID == null) {
                    return ConfigurationManager.AppSettings["SalesforceClientId"];
                }
                else {
                    return _SalesForceClientID;
                }
            }
            set {
                _SalesForceClientID = value;
            }
        }

        private static string _SalesForcePassword;
        public static string SalesforcePassword {
            get {
                if (_SalesForcePassword == null) {
                    return ConfigurationManager.AppSettings["SalesforcePassword"] + SalesforceSecurityToken;
                }
                else {
                    return _SalesForcePassword;
                }
            }
            set {
                _SalesForcePassword = value;
            }
        }

        private static string _SalesForceSecurityToken;
        public static string SalesforceSecurityToken {
            get {
                if (_SalesForceSecurityToken == null) {
                    return ConfigurationManager.AppSettings["SalesforceSecurityToken"];
                }
                else {
                    return _SalesForceSecurityToken;
                }
            }
            set {
                _SalesForceSecurityToken = value;
            }
        }

        private static string _SalesforceUsername;
        public static string SalesforceUsername {
            get {
                if (_SalesforceUsername == null) {
                    return ConfigurationManager.AppSettings["SalesforceUsername"];
                }
                else {
                    return _SalesforceUsername;
                }
            }
            set {
                _SalesforceUsername = value;
            }
        }

        private static string _SalesforceEndPoint;
        public static string SalesforceEndpoint {
            get {
                if (_SalesforceEndPoint == null) {
                    return ConfigurationManager.AppSettings["SalesforceEndpoint"];
                }
                else {
                    return _SalesforceEndPoint;
                }
            }
            set {
                _SalesforceEndPoint = value;
            }
        }

        private static string _SalesForceSecret;
        public static string SalesforceSecret {
            get {
                if (_SalesForceSecret == null) {
                    return ConfigurationManager.AppSettings["SalesforceSecret"];
                }
                else {
                    return _SalesForceSecret;
                }
            }
            set {
                _SalesForceSecret = value;
            }
        }

        public static bool HasManualPassword() => _SalesForcePassword != null;

        public static bool HasManualUserName() => _SalesforceUsername != null;
    }
}
