#region
using System;
using System.IO;
using System.Net;
using System.Text;

#endregion

namespace GitHubNotifier {
    public static class Extensions {
        public static string GetStringFromUrlWithUserPass(this string url, string user = "", string password = "",
                                                          string acceptContentType = "*/*", Action<HttpWebResponse> responseFilter = null) {
            try {
                var webReq = (HttpWebRequest) WebRequest.Create(url);
                webReq.Accept = acceptContentType;

                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                    webReq.SetBasicAuthHeader(user, password);

                using (var webRes = webReq.GetResponse())
                using (var stream = webRes.GetResponseStream())
                using (var reader = new StreamReader(stream)) {
                    if (responseFilter != null)
                        responseFilter((HttpWebResponse) webRes);

                    return reader.ReadToEnd();
                }
            } catch {
                return string.Empty;
            }
        }

        public static void SetBasicAuthHeader(this HttpWebRequest req, string userName, string userPassword) {
            string authInfo = string.Format("{0}:{1}", userName, userPassword);
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

            req.Headers["Authorization"] = "Basic " + authInfo;
        }
    }
}