using System.Text.RegularExpressions;

namespace EncryptionGenie
{
    public partial class DecryptForm : Form
    {
        Controller controller;
        public DecryptForm()
        {
            InitializeComponent();
        }

        private void btn_FileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = oFD_FileExplorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = oFD_FileExplorer.FileName;
                txt_FilePath.Text = file;
            }

            isReadyToDecrypt();
        }

        private async void btn_Decrypt_Click(object sender, EventArgs e)
        {
            controller = new Controller();

            ProgressForm progressForm = new ProgressForm();

            try
            {
                progressForm.StartPosition = FormStartPosition.Manual;
                // calculate the center coordinates of the calling form
                int x = this.Location.X + (this.Width - progressForm.Width) / 2;
                int y = this.Location.Y + (this.Height - progressForm.Height) / 2;
                progressForm.Location = new Point(x, y);
                progressForm.Show();

                string outFile = await controller.decryptFile(txt_FilePath.Text, textBox_Password.Text, progressForm);

                lbl_DecryptProgressReport.ForeColor = Color.Green;
                lbl_DecryptProgressReport.Text = "The decrypted file is located at: " + outFile;

            }
            catch (Exception ex)
            {
                lbl_DecryptProgressReport.ForeColor = Color.Red;
                lbl_DecryptProgressReport.Text = ex.ToString();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                progressForm.Close();
            }
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

            isReadyToDecrypt();

        }

        private void isReadyToDecrypt()
        {
            bool isReady = false;

            //commented below as we dont want attackers to know the requirements of a password
            //if (ValidatePassword() && File.Exists(txt_FilePath.Text))
            //    isReady = true;

            if (File.Exists(txt_FilePath.Text))
                if (textBox_Password.Text.Length > 0)
                    isReady = true;


            btn_Decrypt.Enabled = isReady;

        }

        private bool ValidatePassword()
        {
            string password = textBox_Password.Text;
            // Set password requirements
            int minLength = 8;
            string complexityRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            // Check password length
            if (password.Length < minLength)
            {
                return false;
            }

            // Check password complexity
            if (!Regex.IsMatch(password, complexityRegex))
            {
                return false;
            }

            // Password is valid
            return true;
        }


        private void txt_FilePath_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(txt_FilePath.Text) && txt_FilePath.TextLength != 0)
            {
                lbl_FileValidation.Text = "Invalid file path. Please check.";
                txt_FilePath.BackColor = Color.LightPink;
                lbl_FileValidation.ForeColor = Color.Red;
            }
            else
            {
                lbl_FileValidation.Text = "";
                txt_FilePath.BackColor = Color.White;
                //lbl_FileValidation.ForeColor = Color.Green;
            }

            isReadyToDecrypt();
        }

        private void btn_EncryptTab_Click(object sender, EventArgs e)
        {

            EncryptForm encryptForm = Application.OpenForms.OfType<EncryptForm>().FirstOrDefault();

            if (encryptForm == null)
            {
                // Create a new instance of encryptForm if it doesn't exist
                encryptForm = new EncryptForm();
                encryptForm.FormClosed += (s, args) => this.Show(); // Show Form1 when encryptForm is closed
                encryptForm.Show();
                this.Hide();
            }
            else
            {
                // Show the existing instance of encryptForm if it exists
                encryptForm.Show();
                this.Hide();
            }
        }

        private void img_PwdVisible_Click(object sender, EventArgs e)
        {
            img_PwdHidden.Visible = true;
            img_PwdVisible.Visible = false;
            textBox_Password.UseSystemPasswordChar = false;
        }

        private void img_PwdHidden_Click(object sender, EventArgs e)
        {
            img_PwdHidden.Visible = false;
            img_PwdVisible.Visible = true;
            textBox_Password.UseSystemPasswordChar = true;
        }

        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            txt_FilePath.Clear();
            lbl_DecryptProgressReport.Text = string.Empty;
            textBox_Password.Clear();
            textBox_Password.UseSystemPasswordChar = true;
            img_PwdHidden.Visible = false;
            img_PwdVisible.Visible = true;
            lbl_DecryptProgressReport.Text = string.Empty;

        }
    }
}