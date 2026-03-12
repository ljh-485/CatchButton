namespace CatchButton
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RunButton = new Button();
            SuspendLayout();
            // 
            // RunButton
            // 
            RunButton.BackColor = Color.LightBlue;
            RunButton.Font = new Font("맑은 고딕", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 129);
            RunButton.ForeColor = Color.RoyalBlue;
            RunButton.Location = new Point(715, 190);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(359, 155);
            RunButton.TabIndex = 0;
            RunButton.Text = "나를 잡아봐";
            RunButton.UseVisualStyleBackColor = false;
            RunButton.MouseClick += RunButton_MouseClick;
            RunButton.MouseEnter += RunButton_MouseEnter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1276, 719);
            Controls.Add(RunButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        public Button RunButton;
    }
}
