namespace EncryptionGenie
{
    partial class EncryptForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        /// 

        private Button btn_FileBrowse, btn_Encrypt;
        private Label lbl_EncryptionTitle, lbl_FilePath;
        private OpenFileDialog oFD_FileExplorer;
        private ComboBox comboBox_EncAlgo;
        private ComboBox comboBox_HashAlgo;
        private Label lbl_EncAlgo;
        private Label lbl_HashAlgo;
        private Label lbl_PasswordText;
        private Label lbl_PasswordConfirmation;
        private TextBox textBox_Password;
        private TextBox textBox_PasswordConfirm;
        private Button btn_Cancel;
        private Label lbl_PasswordValidation;
        private Label lbl_PasswordMatch;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptForm));
            btn_FileBrowse = new Button();
            btn_Encrypt = new Button();
            lbl_EncryptionTitle = new Label();
            lbl_FilePath = new Label();
            oFD_FileExplorer = new OpenFileDialog();
            comboBox_EncAlgo = new ComboBox();
            comboBox_HashAlgo = new ComboBox();
            lbl_EncAlgo = new Label();
            lbl_HashAlgo = new Label();
            lbl_PasswordText = new Label();
            lbl_PasswordConfirmation = new Label();
            textBox_Password = new TextBox();
            textBox_PasswordConfirm = new TextBox();
            btn_Cancel = new Button();
            lbl_PasswordValidation = new Label();
            lbl_PasswordMatch = new Label();
            lbl_FileValidation = new Label();
            txt_FilePath = new TextBox();
            btn_EncryptTab = new Button();
            btn_DecryptTab = new Button();
            img_PwdHidden = new PictureBox();
            img_PwdConfirmHidden = new PictureBox();
            img_PwdVisible = new PictureBox();
            img_PwdConfirmVisible = new PictureBox();
            btn_ClearAll = new Button();
            lbl_EncProgressReport = new Label();
            ((System.ComponentModel.ISupportInitialize)img_PwdHidden).BeginInit();
            ((System.ComponentModel.ISupportInitialize)img_PwdConfirmHidden).BeginInit();
            ((System.ComponentModel.ISupportInitialize)img_PwdVisible).BeginInit();
            ((System.ComponentModel.ISupportInitialize)img_PwdConfirmVisible).BeginInit();
            SuspendLayout();
            // 
            // btn_FileBrowse
            // 
            btn_FileBrowse.AutoSize = true;
            btn_FileBrowse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_FileBrowse.BackColor = Color.LightBlue;
            btn_FileBrowse.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_FileBrowse.Location = new Point(611, 68);
            btn_FileBrowse.Name = "btn_FileBrowse";
            btn_FileBrowse.Size = new Size(71, 28);
            btn_FileBrowse.TabIndex = 0;
            btn_FileBrowse.Text = "Browse";
            btn_FileBrowse.UseVisualStyleBackColor = false;
            btn_FileBrowse.Click += btn_FileBrowse_Click;
            // 
            // btn_Encrypt
            // 
            btn_Encrypt.AutoSize = true;
            btn_Encrypt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Encrypt.BackColor = Color.LightGray;
            btn_Encrypt.Enabled = false;
            btn_Encrypt.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Encrypt.Location = new Point(608, 553);
            btn_Encrypt.Name = "btn_Encrypt";
            btn_Encrypt.Size = new Size(70, 28);
            btn_Encrypt.TabIndex = 1;
            btn_Encrypt.Text = "Encrypt";
            btn_Encrypt.UseVisualStyleBackColor = false;
            btn_Encrypt.Click += btn_Encrypt_Click;
            // 
            // lbl_EncryptionTitle
            // 
            lbl_EncryptionTitle.Font = new Font("Arial", 12.8571434F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_EncryptionTitle.ForeColor = Color.DarkBlue;
            lbl_EncryptionTitle.Location = new Point(2, 1);
            lbl_EncryptionTitle.Name = "lbl_EncryptionTitle";
            lbl_EncryptionTitle.Size = new Size(255, 50);
            lbl_EncryptionTitle.TabIndex = 4;
            lbl_EncryptionTitle.Text = "Encrypt Your Files";
            lbl_EncryptionTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_FilePath
            // 
            lbl_FilePath.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_FilePath.Location = new Point(45, 76);
            lbl_FilePath.Name = "lbl_FilePath";
            lbl_FilePath.Size = new Size(117, 30);
            lbl_FilePath.TabIndex = 3;
            lbl_FilePath.Text = "File Path:";
            lbl_FilePath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // oFD_FileExplorer
            // 
            oFD_FileExplorer.Filter = "All Files (*.*)|*.*";
            oFD_FileExplorer.Title = "Select a text file";
            // 
            // comboBox_EncAlgo
            // 
            comboBox_EncAlgo.BackColor = Color.LightBlue;
            comboBox_EncAlgo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_EncAlgo.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point);
            comboBox_EncAlgo.ForeColor = Color.Gray;
            comboBox_EncAlgo.FormattingEnabled = true;
            comboBox_EncAlgo.Items.AddRange(new object[] { "Select an option...", "3DES", "AES128", "AES256" });
            comboBox_EncAlgo.Location = new Point(323, 156);
            comboBox_EncAlgo.Name = "comboBox_EncAlgo";
            comboBox_EncAlgo.Size = new Size(282, 27);
            comboBox_EncAlgo.TabIndex = 5;
            comboBox_EncAlgo.SelectedIndex = 0;
            comboBox_EncAlgo.DropDown += comboBox_EncAlgo_DropDown;
            comboBox_EncAlgo.SelectedIndexChanged += comboBox_EncAlgo_SelectedIndexChanged;
            // 
            // comboBox_HashAlgo
            // 
            comboBox_HashAlgo.BackColor = Color.LightBlue;
            comboBox_HashAlgo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_HashAlgo.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point);
            comboBox_HashAlgo.ForeColor = Color.Gray;
            comboBox_HashAlgo.FormattingEnabled = true;
            comboBox_HashAlgo.Items.AddRange(new object[] { "Select an option...", "SHA256", "SHA512" });
            comboBox_HashAlgo.Location = new Point(326, 240);
            comboBox_HashAlgo.Name = "comboBox_HashAlgo";
            comboBox_HashAlgo.Size = new Size(279, 27);
            comboBox_HashAlgo.TabIndex = 5;
            comboBox_HashAlgo.SelectedIndex = 0;
            comboBox_HashAlgo.DropDown += comboBox_HashAlgo_DropDown;
            comboBox_HashAlgo.SelectedIndexChanged += comboBox_HashAlgo_SelectedIndexChanged;
            // 
            // lbl_EncAlgo
            // 
            lbl_EncAlgo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_EncAlgo.Location = new Point(45, 142);
            lbl_EncAlgo.Name = "lbl_EncAlgo";
            lbl_EncAlgo.Size = new Size(256, 62);
            lbl_EncAlgo.TabIndex = 7;
            lbl_EncAlgo.Text = "Encryption Algorithm:";
            lbl_EncAlgo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_HashAlgo
            // 
            lbl_HashAlgo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_HashAlgo.Location = new Point(45, 226);
            lbl_HashAlgo.Name = "lbl_HashAlgo";
            lbl_HashAlgo.Size = new Size(227, 62);
            lbl_HashAlgo.TabIndex = 8;
            lbl_HashAlgo.Text = "Hashing Algorithm:";
            lbl_HashAlgo.TextAlign = ContentAlignment.MiddleLeft;
            lbl_HashAlgo.Click += lbl_HashAlgo_Click;
            // 
            // lbl_PasswordText
            // 
            lbl_PasswordText.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_PasswordText.Location = new Point(45, 314);
            lbl_PasswordText.Name = "lbl_PasswordText";
            lbl_PasswordText.Size = new Size(167, 30);
            lbl_PasswordText.TabIndex = 9;
            lbl_PasswordText.Text = "Password:";
            lbl_PasswordText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_PasswordConfirmation
            // 
            lbl_PasswordConfirmation.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_PasswordConfirmation.Location = new Point(45, 417);
            lbl_PasswordConfirmation.Name = "lbl_PasswordConfirmation";
            lbl_PasswordConfirmation.Size = new Size(256, 30);
            lbl_PasswordConfirmation.TabIndex = 10;
            lbl_PasswordConfirmation.Text = "Re-enter Password:";
            lbl_PasswordConfirmation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Password
            // 
            textBox_Password.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_Password.Location = new Point(326, 313);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.PlaceholderText = "Enter a password";
            textBox_Password.Size = new Size(279, 26);
            textBox_Password.TabIndex = 11;
            textBox_Password.UseSystemPasswordChar = true;
            textBox_Password.TextChanged += txtPassword_TextChanged;
            // 
            // textBox_PasswordConfirm
            // 
            textBox_PasswordConfirm.Enabled = false;
            textBox_PasswordConfirm.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_PasswordConfirm.Location = new Point(323, 412);
            textBox_PasswordConfirm.Name = "textBox_PasswordConfirm";
            textBox_PasswordConfirm.PlaceholderText = "Repeat the password";
            textBox_PasswordConfirm.Size = new Size(282, 26);
            textBox_PasswordConfirm.TabIndex = 12;
            textBox_PasswordConfirm.UseSystemPasswordChar = true;
            textBox_PasswordConfirm.TextChanged += txtPassword_TextChanged;
            // 
            // btn_Cancel
            // 
            btn_Cancel.AutoSize = true;
            btn_Cancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Cancel.BackColor = Color.LightBlue;
            btn_Cancel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Cancel.Location = new Point(326, 553);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(67, 28);
            btn_Cancel.TabIndex = 13;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = false;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // lbl_PasswordValidation
            // 
            lbl_PasswordValidation.Font = new Font("Arial", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_PasswordValidation.Location = new Point(326, 347);
            lbl_PasswordValidation.Name = "lbl_PasswordValidation";
            lbl_PasswordValidation.Size = new Size(316, 47);
            lbl_PasswordValidation.TabIndex = 15;
            lbl_PasswordValidation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_PasswordMatch
            // 
            lbl_PasswordMatch.Font = new Font("Arial", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_PasswordMatch.Location = new Point(326, 455);
            lbl_PasswordMatch.Name = "lbl_PasswordMatch";
            lbl_PasswordMatch.Size = new Size(316, 30);
            lbl_PasswordMatch.TabIndex = 16;
            lbl_PasswordMatch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_FileValidation
            // 
            lbl_FileValidation.Font = new Font("Arial", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_FileValidation.Location = new Point(168, 114);
            lbl_FileValidation.Name = "lbl_FileValidation";
            lbl_FileValidation.Size = new Size(231, 28);
            lbl_FileValidation.TabIndex = 17;
            lbl_FileValidation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_FilePath
            // 
            txt_FilePath.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_FilePath.Location = new Point(168, 70);
            txt_FilePath.Name = "txt_FilePath";
            txt_FilePath.PlaceholderText = "Type file path or click Browse";
            txt_FilePath.Size = new Size(437, 26);
            txt_FilePath.TabIndex = 2;
            txt_FilePath.TextChanged += txt_FilePath_TextChanged;
            // 
            // btn_EncryptTab
            // 
            btn_EncryptTab.AutoSize = true;
            btn_EncryptTab.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_EncryptTab.BackColor = Color.LightGray;
            btn_EncryptTab.Enabled = false;
            btn_EncryptTab.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_EncryptTab.Location = new Point(406, 5);
            btn_EncryptTab.Name = "btn_EncryptTab";
            btn_EncryptTab.Size = new Size(103, 29);
            btn_EncryptTab.TabIndex = 18;
            btn_EncryptTab.Text = "Encryption";
            btn_EncryptTab.UseVisualStyleBackColor = false;
            // 
            // btn_DecryptTab
            // 
            btn_DecryptTab.AutoSize = true;
            btn_DecryptTab.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_DecryptTab.BackColor = Color.LightBlue;
            btn_DecryptTab.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_DecryptTab.Location = new Point(582, 5);
            btn_DecryptTab.Name = "btn_DecryptTab";
            btn_DecryptTab.Size = new Size(93, 28);
            btn_DecryptTab.TabIndex = 19;
            btn_DecryptTab.Text = "Decryption";
            btn_DecryptTab.UseVisualStyleBackColor = false;
            btn_DecryptTab.Click += btn_DecryptTab_Click;
            // 
            // img_PwdHidden
            // 
            img_PwdHidden.Image = Properties.Resources.hidden;
            img_PwdHidden.Location = new Point(608, 318);
            img_PwdHidden.Name = "img_PwdHidden";
            img_PwdHidden.Size = new Size(34, 26);
            img_PwdHidden.SizeMode = PictureBoxSizeMode.StretchImage;
            img_PwdHidden.TabIndex = 20;
            img_PwdHidden.TabStop = false;
            img_PwdHidden.Visible = false;
            img_PwdHidden.Click += img_PwdHidden_Click;
            // 
            // img_PwdConfirmHidden
            // 
            img_PwdConfirmHidden.Image = Properties.Resources.hidden;
            img_PwdConfirmHidden.Location = new Point(608, 418);
            img_PwdConfirmHidden.Name = "img_PwdConfirmHidden";
            img_PwdConfirmHidden.Size = new Size(34, 26);
            img_PwdConfirmHidden.SizeMode = PictureBoxSizeMode.StretchImage;
            img_PwdConfirmHidden.TabIndex = 21;
            img_PwdConfirmHidden.TabStop = false;
            img_PwdConfirmHidden.Visible = false;
            img_PwdConfirmHidden.Click += img_PwdConfirmHidden_Click;
            // 
            // img_PwdVisible
            // 
            img_PwdVisible.Image = Properties.Resources.visible;
            img_PwdVisible.Location = new Point(608, 318);
            img_PwdVisible.Name = "img_PwdVisible";
            img_PwdVisible.Size = new Size(34, 26);
            img_PwdVisible.SizeMode = PictureBoxSizeMode.StretchImage;
            img_PwdVisible.TabIndex = 22;
            img_PwdVisible.TabStop = false;
            img_PwdVisible.Click += img_PwdVisible_Click;
            // 
            // img_PwdConfirmVisible
            // 
            img_PwdConfirmVisible.Image = Properties.Resources.visible;
            img_PwdConfirmVisible.Location = new Point(608, 418);
            img_PwdConfirmVisible.Name = "img_PwdConfirmVisible";
            img_PwdConfirmVisible.Size = new Size(34, 26);
            img_PwdConfirmVisible.SizeMode = PictureBoxSizeMode.StretchImage;
            img_PwdConfirmVisible.TabIndex = 23;
            img_PwdConfirmVisible.TabStop = false;
            img_PwdConfirmVisible.Click += img_PwdConfirmVisible_Click;
            // 
            // btn_ClearAll
            // 
            btn_ClearAll.AutoSize = true;
            btn_ClearAll.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_ClearAll.BackColor = Color.LightBlue;
            btn_ClearAll.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ClearAll.Location = new Point(462, 553);
            btn_ClearAll.Name = "btn_ClearAll";
            btn_ClearAll.Size = new Size(76, 28);
            btn_ClearAll.TabIndex = 24;
            btn_ClearAll.Text = "Clear All";
            btn_ClearAll.UseVisualStyleBackColor = false;
            btn_ClearAll.Click += btn_ClearAll_Click;
            // 
            // lbl_EncProgressReport
            // 
            lbl_EncProgressReport.Font = new Font("Arial", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_EncProgressReport.Location = new Point(45, 500);
            lbl_EncProgressReport.Name = "lbl_EncProgressReport";
            lbl_EncProgressReport.Size = new Size(666, 30);
            lbl_EncProgressReport.TabIndex = 25;
            lbl_EncProgressReport.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EncryptForm
            // 
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(746, 622);
            Controls.Add(lbl_EncProgressReport);
            Controls.Add(btn_ClearAll);
            Controls.Add(img_PwdConfirmVisible);
            Controls.Add(img_PwdVisible);
            Controls.Add(img_PwdConfirmHidden);
            Controls.Add(img_PwdHidden);
            Controls.Add(btn_DecryptTab);
            Controls.Add(btn_EncryptTab);
            Controls.Add(lbl_FileValidation);
            Controls.Add(lbl_PasswordMatch);
            Controls.Add(lbl_PasswordValidation);
            Controls.Add(btn_Cancel);
            Controls.Add(textBox_PasswordConfirm);
            Controls.Add(textBox_Password);
            Controls.Add(lbl_PasswordConfirmation);
            Controls.Add(lbl_PasswordText);
            Controls.Add(lbl_HashAlgo);
            Controls.Add(lbl_EncAlgo);
            Controls.Add(comboBox_HashAlgo);
            Controls.Add(comboBox_EncAlgo);
            Controls.Add(btn_FileBrowse);
            Controls.Add(btn_Encrypt);
            Controls.Add(txt_FilePath);
            Controls.Add(lbl_FilePath);
            Controls.Add(lbl_EncryptionTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EncryptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EncryptionGenie";
            ((System.ComponentModel.ISupportInitialize)img_PwdHidden).EndInit();
            ((System.ComponentModel.ISupportInitialize)img_PwdConfirmHidden).EndInit();
            ((System.ComponentModel.ISupportInitialize)img_PwdVisible).EndInit();
            ((System.ComponentModel.ISupportInitialize)img_PwdConfirmVisible).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion




        private Label lbl_FileValidation;
        private TextBox txt_FilePath;
        private Button btn_EncryptTab;
        private Button btn_DecryptTab;
        private PictureBox img_PwdHidden;
        private PictureBox img_PwdConfirmHidden;
        private PictureBox img_PwdVisible;
        private PictureBox img_PwdConfirmVisible;
        private Button btn_ClearAll;
        private Label lbl_EncProgressReport;


        public TextBox TextBox_Password { get => textBox_Password; set => textBox_Password = value; }
        public Label Lbl_EncProgressReport { get => lbl_EncProgressReport; set => lbl_EncProgressReport = value; }
        public ComboBox ComboBox_EncAlgo { get => comboBox_EncAlgo; set => comboBox_EncAlgo = value; }
        public ComboBox ComboBox_HashAlgo { get => comboBox_HashAlgo; set => comboBox_HashAlgo = value; }
        public TextBox Txt_FilePath { get => txt_FilePath; set => txt_FilePath = value; }
    }
}