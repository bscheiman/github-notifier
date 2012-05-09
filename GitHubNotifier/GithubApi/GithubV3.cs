#region
using System.Collections.Generic;
using System.Linq;
using ServiceStack.Text;

#endregion

namespace GitHubNotifier.GithubApi {
    public class GithubV3 {
        public const string GithubApiBaseUrl = "https://api.github.com/";
        public string Password { get; set; }
        public string Username { get; set; }

        public GithubV3(string username, string password) {
            Username = username;
            Password = password;
        }

        public IEnumerable<GithubIssue> GetAssignedIssues() {
            try {
                return GetIssues().Where(i => i.Assignee.Login == Username).ToList();
            } catch {
                return new List<GithubIssue>();
            }
        }

        public IEnumerable<GithubIssue> GetIssues() {
            try {
                return GetJson<List<GithubIssue>>("issues").Where(i => i.State == "open").ToList();
            } catch {
                return new List<GithubIssue>();
            }
        }

        public T GetJson<T>(string route, params object[] routeArgs) {
            return GithubApiBaseUrl.AppendPath(route.Fmt(routeArgs)).GetStringFromUrlWithUserPass(Username, Password).FromJson<T>();
        }
    }
}