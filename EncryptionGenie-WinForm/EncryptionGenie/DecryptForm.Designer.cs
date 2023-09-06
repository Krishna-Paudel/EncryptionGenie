namespace EncryptionGenie
{
    partial class DecryptForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        /// 

        private Button btn_FileBrowse, btn_Decrypt;
        private TextBox txt_FilePath;
        private Label lbl_DecryptionTitle, lbl_FilePath;
        private OpenFileDialog oFD_FileExplorer;
        private Label lbl_PasswordText;

        private TextBox textBox_Password;

        private Button btn_Cancel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecryptForm));
            btn_FileBrowse = new Button();
            btn_Decrypt = new Button();
            txt_FilePath = new TextBox();
            lbl_DecryptionTitle = new Label();
            lbl_FilePath = new Label();
            oFD_FileExplorer = new OpenFileDialog();
            lbl_PasswordText = new Label();
            textBox_Password = new TextBox();
            btn_Cancel = new Button();
            lbl_FileValidation = new Label();
            btn_DecryptTab = new Button();
            btn_EncryptTab = new Button();
            lbl_DecryptProgressReport = new Label();
            img_PwdHidden = new PictureBox();
            img_PwdVisible = new PictureBox();
            btn_ClearAll = new Button();
            ((System.ComponentModel.ISupportInitialize)img_PwdHidden).BeginInit();
            ((System.ComponentModel.ISupportInitialize)img_PwdVisible).BeginInit();
            SuspendLayout();
            // 
            // btn_FileBrowse
            // 
            btn_FileBrowse.AutoSize = true;
            btn_FileBrowse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_FileBrowse.BackColor = Color.LightBlue;
            btn_FileBrowse.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_FileBrowse.Location = new Point(611, 71);
            btn_FileBrowse.Name = "btn_FileBrowse";
            btn_FileBrowse.Size = new Size(71, 28);
            btn_FileBrowse.TabIndex = 0;
            btn_FileBrowse.Text = "Browse";
            btn_FileBrowse.UseVisualStyleBackColor = false;
            btn_FileBrowse.Click += btn_FileBrowse_Click;
            // 
            // btn_Decrypt
            // 
            btn_Decrypt.AutoSize = true;
            btn_Decrypt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Decrypt.BackColor = Color.LightBlue;
            btn_Decrypt.Enabled = false;
            btn_Decrypt.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Decrypt.Location = new Point(615, 294);
            btn_Decrypt.Name = "btn_Decrypt";
            btn_Decrypt.Size = new Size(72, 28);
            btn_Decrypt.TabIndex = 1;
            btn_Decrypt.Text = "Decrypt";
            btn_Decrypt.UseVisualStyleBackColor = false;
            btn_Decrypt.Click += btn_Decrypt_Click;
            // 
            // txt_FilePath
            // 
            txt_FilePath.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_FilePath.Location = new Point(190, 73);
            txt_FilePath.Name = "txt_FilePath";
            txt_FilePath.PlaceholderText = "Type file path or click Browse";
            txt_FilePath.Size = new Size(415, 26);
            txt_FilePath.TabIndex = 2;
            txt_FilePath.TextChanged += txt_FilePath_TextChanged;
            // 
            // lbl_DecryptionTitle
            // 
            lbl_DecryptionTitle.Font = new Font("Arial", 12.8571434F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_DecryptionTitle.ForeColor = Color.DarkBlue;
            lbl_DecryptionTitle.Location = new Point(2, 1);
            lbl_DecryptionTitle.Name = "lbl_DecryptionTitle";
            lbl_DecryptionTitle.Size = new Size(252, 50);
            lbl_DecryptionTitle.TabIndex = 4;
            lbl_DecryptionTitle.Text = "Decrypt Your Files";
            lbl_DecryptionTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_FilePath
            // 
            lbl_FilePath.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_FilePath.Location = new Point(45, 71);
            lbl_FilePath.Name = "lbl_FilePath";
            lbl_FilePath.Size = new Size(124, 30);
            lbl_FilePath.TabIndex = 3;
            lbl_FilePath.Text = "File Path:";
            lbl_FilePath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // oFD_FileExplorer
            // 
            oFD_FileExplorer.Filter = "Encrypted Files (*.enc)|*.enc";
            oFD_FileExplorer.Title = "Select a text file";
            // 
            // lbl_PasswordText
            // 
            lbl_PasswordText.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_PasswordText.Location = new Point(45, 166);
            lbl_PasswordText.Name = "lbl_PasswordText";
            lbl_PasswordText.Size = new Size(124, 30);
            lbl_PasswordText.TabIndex = 9;
            lbl_PasswordText.Text = "Password:";
            lbl_PasswordText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Password
            // 
            textBox_Password.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_Password.Location = new Point(190, 166);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.PlaceholderText = "Enter a password";
            textBox_Password.Size = new Size(415, 26);
            textBox_Password.TabIndex = 11;
            textBox_Password.UseSystemPasswordChar = true;
            textBox_Password.TextChanged += txtPassword_TextChanged;
            // 
            // btn_Cancel
            // 
            btn_Cancel.AutoSize = true;
            btn_Cancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Cancel.BackColor = Color.LightBlue;
            btn_Cancel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Cancel.Location = new Point(333, 294);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(67, 28);
            btn_Cancel.TabIndex = 13;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = false;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // lbl_FileValidation
            // 
            lbl_FileValidation.Font = new Font("Arial", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_FileValidation.Location = new Point(190, 117);
            lbl_FileValidation.Name = "lbl_FileValidation";
            lbl_FileValidation.Size = new Size(415, 25);
            lbl_FileValidation.TabIndex = 17;
            lbl_FileValidation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_DecryptTab
            // 
            btn_DecryptTab.AutoSize = true;
            btn_DecryptTab.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_DecryptTab.BackColor = Color.LightGray;
            btn_DecryptTab.Enabled = false;
            btn_DecryptTab.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_DecryptTab.Location = new Point(580, 1);
            btn_DecryptTab.Name = "btn_DecryptTab";
            btn_DecryptTab.Size = new Size(103, 29);
            btn_DecryptTab.TabIndex = 21;
            btn_DecryptTab.Text = "Decryption";
            btn_DecryptTab.UseVisualStyleBackColor = false;
            // 
            // btn_EncryptTab
            // 
            btn_EncryptTab.AutoSize = true;
            btn_EncryptTab.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_EncryptTab.BackColor = Color.LightBlue;
            btn_EncryptTab.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_EncryptTab.Location = new Point(425, 1);
            btn_EncryptTab.Name = "btn_EncryptTab";
            btn_EncryptTab.Size = new Size(91, 28);
            btn_EncryptTab.TabIndex = 20;
            btn_EncryptTab.Text = "Encryption";
            btn_EncryptTab.UseVisualStyleBackColor = false;
            btn_EncryptTab.Click += btn_EncryptTab_Click;
            // 
            // lbl_DecryptProgressReport
            // 
            lbl_DecryptProgressReport.Font = new Font("Arial", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_DecryptProgressReport.Location = new Point(45, 229);
            lbl_DecryptProgressReport.Name = "lbl_DecryptProgressReport";
            lbl_DecryptProgressReport.Size = new Size(667, 30);
            lbl_DecryptProgressReport.TabIndex = 23;
            lbl_DecryptProgressReport.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // img_PwdHidden
            // 
            img_PwdHidden.Image = Properties.Resources.hidden;
            img_PwdHidden.Location = new Point(479, 166);
            img_PwdHidden.Name = "img_PwdHidden";
            img_PwdHidden.Size = new Size(34, 26);
            img_PwdHidden.SizeMode = PictureBoxSizeMode.StretchImage;
            img_PwdHidden.TabIndex = 20;
            img_PwdHidden.TabStop = false;
            img_PwdHidden.Visible = false;
            img_PwdHidden.Click += img_PwdHidden_Click;
            // 
            // img_PwdVisible
            // 
            img_PwdVisible.Image = Properties.Resources.visible;
            img_PwdVisible.Location = new Point(479, 166);
            img_PwdVisible.Name = "img_PwdVisible";
            img_PwdVisible.Size = new Size(34, 26);
            img_PwdVisible.SizeMode = PictureBoxSizeMode.StretchImage;
            img_PwdVisible.TabIndex = 22;
            img_PwdVisible.TabStop = false;
            img_PwdVisible.Click += img_PwdVisible_Click;
            // 
            // btn_ClearAll
            // 
            btn_ClearAll.AutoSize = true;
            btn_ClearAll.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_ClearAll.BackColor = Color.LightBlue;
            btn_ClearAll.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ClearAll.Location = new Point(468, 294);
            btn_ClearAll.Name = "btn_ClearAll";
            btn_ClearAll.Size = new Size(76, 28);
            btn_ClearAll.TabIndex = 24;
            btn_ClearAll.Text = "Clear All";
            btn_ClearAll.UseVisualStyleBackColor = false;
            btn_ClearAll.Click += btn_ClearAll_Click;
            // 
            // DecryptForm
            // 
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(748, 377);
            Controls.Add(btn_ClearAll);
            Controls.Add(lbl_DecryptProgressReport);
            Controls.Add(btn_DecryptTab);
            Controls.Add(btn_EncryptTab);
            Controls.Add(lbl_FileValidation);
            Controls.Add(btn_Cancel);
            Controls.Add(textBox_Password);
            Controls.Add(lbl_PasswordText);
            Controls.Add(img_PwdHidden);
            Controls.Add(img_PwdVisible);
            Controls.Add(btn_FileBrowse);
            Controls.Add(btn_Decrypt);
            Controls.Add(txt_FilePath);
            Controls.Add(lbl_FilePath);
            Controls.Add(lbl_DecryptionTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DecryptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EncryptionGenie";
            ((System.ComponentModel.ISupportInitialize)img_PwdHidden).EndInit();
            ((System.ComponentModel.ISupportInitialize)img_PwdVisible).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion




        private Label lbl_FileValidation;
        private Button btn_DecryptTab;
        private Button btn_EncryptTab;
        private Label lbl_DecryptProgressReport;
        private PictureBox img_PwdHidden;
        private PictureBox img_PwdVisible;
        private Button btn_ClearAll;
    }
}