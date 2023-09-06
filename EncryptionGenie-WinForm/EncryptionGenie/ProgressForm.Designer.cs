namespace EncryptionGenie
{
    partial class ProgressForm
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

        protected override CreateParams CreateParams
        {
            get
            {
                // Hide the minimize, maximize, and close buttons
                const int WS_MINIMIZEBOX = 0x20000;
                const int WS_MAXIMIZEBOX = 0x10000;
                const int WS_SYSMENU = 0x80000;
                CreateParams cp = base.CreateParams;
                cp.Style &= ~(WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SYSMENU);

                // Disable resizing
                const int CS_DBLCLKS = 0x8;
                const int WS_SIZEBOX = 0x40000;
                cp.Style &= ~(WS_SIZEBOX);
                cp.ClassStyle |= CS_DBLCLKS;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED to reduce flickering
                return cp;
            }
        }

        public Label Lbl_EncProgressReport { get => lbl_EncProgressReport; set => lbl_EncProgressReport = value; }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar = new ProgressBar();
            lbl_EncProgress = new Label();
            lbl_EncProgressReport = new Label();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 69);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(620, 23);
            progressBar.TabIndex = 0;
            // 
            // lbl_EncProgress
            // 
            lbl_EncProgress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EncProgress.Location = new Point(12, 18);
            lbl_EncProgress.Name = "lbl_EncProgress";
            lbl_EncProgress.Size = new Size(167, 30);
            lbl_EncProgress.TabIndex = 15;
            lbl_EncProgress.Text = "Encryption Progress:";
            lbl_EncProgress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_EncProgressReport
            // 
            lbl_EncProgressReport.Font = new Font("Arial", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_EncProgressReport.Location = new Point(164, 20);
            lbl_EncProgressReport.Name = "lbl_EncProgressReport";
            lbl_EncProgressReport.Size = new Size(468, 30);
            lbl_EncProgressReport.TabIndex = 26;
            lbl_EncProgressReport.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ProgressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 124);
            Controls.Add(lbl_EncProgressReport);
            Controls.Add(lbl_EncProgress);
            Controls.Add(progressBar);
            Name = "ProgressForm";
            Text = "ProgressForm";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
        private Label lbl_EncProgress;
        private Label lbl_EncProgressReport;
    }
}