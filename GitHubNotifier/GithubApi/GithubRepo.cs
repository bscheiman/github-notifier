#region
using System;

#endregion

namespace GitHubNotifier.GithubApi {
    public class GithubRepo {
        public string Clone_Url { get; set; }
        public DateTime Created_at { get; set; }
        public string Description { get; set; }
        public bool Fork { get; set; }
        public int Forks { get; set; }
        public string Git_Url { get; set; }
        public bool Has_Downloads { get; set; }
        public bool Has_Wiki { get; set; }
        public bool Has_issues { get; set; }
        public string Homepage { get; set; }
        public string Html_Url { get; set; }
        public int Id { get; set; }
        public string Language { get; set; }
        public string Mirror_Url { get; set; }
        public string Name { get; set; }
        public string Open_Issues { get; set; }
        public GithubUser Owner { get; set; }
        public bool Private { get; set; }
        public DateTime? Pushed_At { get; set; }
        public int Size { get; set; }
        public string Ssh_Url { get; set; }
        public string Svn_Url { get; set; }
        public DateTime? Updated_At { get; set; }
        public string Url { get; set; }
        public int Watchers { get; set; }
    }
}