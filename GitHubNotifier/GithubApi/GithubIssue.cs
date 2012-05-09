#region
using System;
using System.Collections.Generic;

#endregion

namespace GitHubNotifier.GithubApi {
    public class GithubIssue {
        public GithubUser Assignee { get; set; }
        public string Body { get; set; }
        public DateTime? Created_At { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
        public string Title { get; set; }
        public DateTime? Updated_At { get; set; }
        public string Url { get; set; }
        public GithubUser User { get; set; }
        public List<GithubLabel> Labels { get; set; }
        public string Html_Url { get; set; }
    }
}