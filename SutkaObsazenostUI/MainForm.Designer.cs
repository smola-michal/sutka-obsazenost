namespace SutkaObsazenostUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkRun = new System.Windows.Forms.CheckBox();
            this.textConsole = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // checkRun
            // 
            this.checkRun.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkRun.AutoSize = true;
            this.checkRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkRun.Location = new System.Drawing.Point(0, 0);
            this.checkRun.Name = "checkRun";
            this.checkRun.Size = new System.Drawing.Size(384, 23);
            this.checkRun.TabIndex = 0;
            this.checkRun.Text = "Run";
            this.checkRun.UseVisualStyleBackColor = true;
            this.checkRun.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textConsole
            // 
            this.textConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textConsole.Location = new System.Drawing.Point(0, 23);
            this.textConsole.Multiline = true;
            this.textConsole.Name = "textConsole";
            this.textConsole.Size = new System.Drawing.Size(384, 539);
            this.textConsole.TabIndex = 1;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Minimized";
            this.notifyIcon.BalloonTipTitle = "Šutka";
            this.notifyIcon.Text = "Šutka";
            this.notifyIcon.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 562);
            this.Controls.Add(this.textConsole);
            this.Controls.Add(this.checkRun);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Šutka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkRun;
        private System.Windows.Forms.TextBox textConsole;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

