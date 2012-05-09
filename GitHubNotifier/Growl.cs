#region
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using GitHubNotifier.GithubApi;
using Growl.Connector;

#endregion

namespace GitHubNotifier {
    public static class Growl {
        private static GrowlConnector _connector;

        public static GrowlConnector Connector {
            get { return _connector ?? (_connector = new GrowlConnector()); }
        }

        public static void Connect() {
            var asm = Assembly.GetExecutingAssembly();
            Image icon;

            using (var stream = asm.GetManifestResourceStream("GitHubNotifier.Embedded.github.png"))
                icon = Image.FromStream(stream);

            var app = new Application("Github Notifier") {
                Icon = icon
            };

            var issueNotification = new NotificationType("ISSUE", "New issue");

            Connector.Register(app, new[] {
                issueNotification
            });

            Connector.NotificationCallback += ConnectorOnNotificationCallback;
        }

        private static void ConnectorOnNotificationCallback(Response response, CallbackData callbackData, object state) {
            Process.Start(callbackData.Data);
        }

        public static void NotifyIssue(GithubIssue issue) {
            Connector.Notify(new Notification("Github Notifier", "ISSUE", issue.Number.ToString(), issue.Title, issue.Body),
                             new CallbackContext(issue.Html_Url));
        }
    }
}