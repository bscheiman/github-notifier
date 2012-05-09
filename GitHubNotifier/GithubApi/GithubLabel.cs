#region
using System.Drawing;

#endregion

namespace GitHubNotifier.GithubApi {
    public class GithubLabel {
        public string Color { get; set; }
        public string Name { get; set; }

        public Color RealColor {
            get {
                try {
                    return ColorTranslator.FromHtml(string.Format("#{0}", Color));
                } catch {
                    return System.Drawing.Color.White;
                }
            }
        }

        public string Url { get; set; }
    }
}