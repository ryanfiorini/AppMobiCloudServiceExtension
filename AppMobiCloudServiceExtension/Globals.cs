using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMobi.AppMobiCloudServiceExtension
{
    public static class Globals
    {
        // Windows Live variables START
        public const string ENDPOINT_OAUTH = "https://oauth.live.com/";
        public const string ENDPOINT_PATH_TOKEN = "token?";
        public const string PARAM_CLIENT_ID = "client_id=";
        public const string PARAM_REDIRECT_URI = "&redirect_uri=";
        public const string PARAM_CLIENT_SECRET = "&client_secret=";
        public const string PARAM_CODE = "&code=";
        public const string PARAM_GRANT_TYPE = "&grant_type=";
        public const string PARAM_GRANT_TYPE_AUTHORIZATION_CODE = "authorization_code";

        public const string PARAM_REFRESH_TOKEN = "&refresh_token=";
        public const string PARAM_GRANT_TYPE_REFRESH_TOKEN = "refresh_token";

        public const string APP_CLIENT_ID = "00000000480D25A0";
        public const string APP_REDIRECT_URI = "http://enterprise.appmobi.com/csd/WindowsLiveCallback2.aspx";
        public const string APP_CLIENT_SECRET = "ELxdqKA4CYeFUxcMV950pe7z8VvRpV5H";


        public const string ENDPOINT_REST_API = "https://apis.live.net/";
        public const string ENDPOINT_REST_API_VERSION = "v5.0/";
        public const string PARAM_ACCESS_TOKEN = "?access_token=";

        public const int REST_API_GET = 2;
        public const int REST_API_POST = 3;

        public const string REST_PATH_ME = "me/";

        public const string ENDPOINT_PATH_AUTHORIZE = "authorize?";
        public const string PARAM_SCOPE = "&scope=";
        public const string REQUESTED_SCOPES = "wl.offline_access%20wl.basic%20wl.emails";
        public const string PARAM_RESPONSE_TYPE = "&response_type=";
        public const string PARAM_RESPONSE_TYPE_CODE = "code";
        // Windows Live variables END
    }
}
