using System;
using System.Windows.Forms;

namespace CatchButton
{
    public class GameOverForm : Form
    {
        private Button confirmButton;
        private Button restartButton;

        public bool RestartClicked { get; private set; }

        public GameOverForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Game Over";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(300, 120);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;

            var label = new Label()
            {
                Text = "Game Over",
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40
            };
            this.Controls.Add(label);

            confirmButton = new Button()
            {
                Text = "확인",
                Width = 100,
                Height = 30,
                Left = 40,
                Top = 60,
                DialogResult = DialogResult.OK
            };
            confirmButton.Click += (s, e) => { RestartClicked = false; this.Close(); };
            this.Controls.Add(confirmButton);

            restartButton = new Button()
            {
                Text = "다시",
                Width = 100,
                Height = 30,
                Left = 160,
                Top = 60,
                DialogResult = DialogResult.Retry
            };
            restartButton.Click += (s, e) => { RestartClicked = true; this.Close(); };
            this.Controls.Add(restartButton);
        }
    }
}
