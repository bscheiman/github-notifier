#region
using System;

#endregion

namespace GitHubNotifier.GithubApi {
    public class GithubUser {
        public string Avatar_Url { get; set; }
        public string Bio { get; set; }
        public string Blog { get; set; }
        public string Company { get; set; }
        public DateTime? Created_At { get; set; }
        public string Email { get; set; }
        public int? Followers { get; set; }
        public int? Following { get; set; }
        public string Gravatar_Id { get; set; }
        public bool? Hireable { get; set; }
        public string Html_Url { get; set; }
        public int Id { get; set; }
        public string Location { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public int? Public_Gists { get; set; }
        public int? Public_Repos { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }
}