#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GitHubNotifier.GithubApi;
using GitHubNotifier.Properties;

#endregion

namespace GitHubNotifier {
    public partial class FrmMain : Form {
        protected readonly Dictionary<int, bool> CheckedIssues = new Dictionary<int, bool>();
        protected bool IsStarting = true;
        protected GithubV3 Client { get; set; }

        public FrmMain() {
            InitializeComponent();

            txtUsername.Text = Settings.Default.Username;
            txtPassword.Text = Settings.Default.Password;
            chkAutostart.Checked = Settings.Default.Autostart;

            if (!Settings.Default.Autostart || string.IsNullOrEmpty(Settings.Default.Username) ||
                string.IsNullOrEmpty(Settings.Default.Password))
                return;

            Client = new GithubV3(Settings.Default.Username, Settings.Default.Password);

            tmrGithub.Enabled = true;
            CheckIssuesThread();
        }

        private void BtnSaveClick(object sender, EventArgs e) {
            Settings.Default.Username = txtUsername.Text;
            Settings.Default.Password = txtPassword.Text;
            Settings.Default.Autostart = chkAutostart.Checked;

            Settings.Default.Save();

            Client = new GithubV3(Settings.Default.Username, Settings.Default.Password);
            CheckIssuesThread();

            tmrGithub.Enabled = true;
        }

        private void CheckIssues() {
            var githubIssues = Client.GetAssignedIssues();

            foreach (var issue in githubIssues.Where(issue => !CheckedIssues.ContainsKey(issue.Number))) {
                Growl.NotifyIssue(issue);
                CheckedIssues[issue.Number] = true;
            }
        }

        private void CheckIssuesThread() {
            MethodInvoker mi = CheckIssues;

            mi.BeginInvoke(null, null);
        }

        private void FrmMainResize(object sender, EventArgs e) {
            switch (WindowState) {
                case FormWindowState.Minimized:
                    notify.Visible = true;
                    Hide();

                    break;
                case FormWindowState.Normal:
                    notify.Visible = false;
                    break;
            }
        }

        private void NotifyDoubleClick(object sender, EventArgs e) {
            IsStarting = false;

            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        protected override void SetVisibleCore(bool value) {
            base.SetVisibleCore(!IsStarting && value);
        }

        private void TmrGithubTick(object sender, EventArgs e) {
            CheckIssuesThread();
        }
    }
}