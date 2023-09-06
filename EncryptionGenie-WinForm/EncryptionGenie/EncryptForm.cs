using log4net;
using Microsoft.VisualBasic.Logging;
using System.Text.RegularExpressions;

namespace EncryptionGenie
{
    public partial class EncryptForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(EncryptForm));

        Controller controller;
        public EncryptForm()
        {
            InitializeComponent();

        }

        private void comboBox_HashAlgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_HashAlgo.SelectedIndex != 0)
            {
                comboBox_HashAlgo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
                comboBox_HashAlgo.ForeColor = Color.Black;
            }
            else
            {
                comboBox_HashAlgo.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point);
                comboBox_HashAlgo.ForeColor = Color.Gray;
            }
            isReadyToEncrypt();
        }

        private void comboBox_EncAlgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_EncAlgo.SelectedIndex != 0)
            {
                comboBox_EncAlgo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
                comboBox_EncAlgo.ForeColor = Color.Black;
            }
            else
            {
                comboBox_EncAlgo.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point);
                comboBox_EncAlgo.ForeColor = Color.Gray;
            }
            isReadyToEncrypt();
        }

        private void comboBox_HashAlgo_DropDown(object sender, EventArgs e)
        {
            comboBox_HashAlgo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox_HashAlgo.ForeColor = Color.Black;
        }

        private void comboBox_EncAlgo_DropDown(object sender, EventArgs e)
        {
            comboBox_EncAlgo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox_EncAlgo.ForeColor = Color.Black;
        }

        private void btn_FileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = oFD_FileExplorer.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = oFD_FileExplorer.FileName;
                txt_FilePath.Text = file;
            }

            isReadyToEncrypt();
        }

        private async void btn_Encrypt_Click(object sender, EventArgs e)
        {
            controller = new Controller();

            Log.Info("Benchmarking master key generation with Enc Algo = " + comboBox_EncAlgo.Text + " Hash Algo = " + comboBox_HashAlgo.Text  );
            
            controller.benchmarkMasterKeyGen(comboBox_EncAlgo.Text, comboBox_HashAlgo.Text, textBox_Password.Text);

            ProgressForm progressForm = new ProgressForm();

            try
            {
                progressForm.StartPosition = FormStartPosition.Manual;
                // calculate the center coordinates of the calling form
                int x = this.Location.X + (this.Width - progressForm.Width) / 2;
                int y = this.Location.Y + (this.Height - progressForm.Height) / 2;
                progressForm.Location = new Point(x, y);
                progressForm.Show();

                string outFile = await controller.encryptFile(Txt_FilePath.Text, comboBox_EncAlgo.Text, comboBox_HashAlgo.Text, textBox_Password.Text, progressForm);

                lbl_EncProgressReport.ForeColor = Color.Green;
                lbl_EncProgressReport.Text = "The encrypted file is located at: " + outFile;

            }
            catch (Exception ex)
            {
                lbl_EncProgressReport.ForeColor = Color.Red;
                lbl_EncProgressReport.Text = ex.ToString();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                progressForm.Close();
            }
        }

        private void lbl_HashAlgo_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

            // Check if password meets requirements


            if (textBox_Password.TextLength == 0)
            {
                textBox_Password.BackColor = Color.White;
                lbl_PasswordValidation.Visible = false;
                textBox_PasswordConfirm.Enabled = false;
                textBox_PasswordConfirm.BackColor = SystemColors.Window;
            }
            else
            {
                bool isValid = ValidatePassword();
                lbl_PasswordValidation.Visible = true;

                // Update UI based on password validity
                if (isValid)
                {
                    textBox_Password.BackColor = Color.White;
                    lbl_PasswordValidation.Text = "Password meets requirements.";
                    lbl_PasswordValidation.ForeColor = Color.Green;
                    textBox_PasswordConfirm.Enabled = true;
                }
                else
                {
                    textBox_Password.BackColor = Color.LightPink;
                    lbl_PasswordValidation.Text = "Password must contain 1 upper, 1 lower, 1 number, 1 symbol, and be at least 8 characters long.";
                    lbl_PasswordValidation.ForeColor = Color.Red;
                }
            }



            //handle Password Confirmation objects
            if (textBox_PasswordConfirm.TextLength == 0)
            {
                lbl_PasswordMatch.Visible = false;
            }
            else
            {
                bool isMatched = MatchPassword();
                lbl_PasswordMatch.Visible = true;

                // Update UI based on password validity
                if (isMatched)
                {
                    textBox_PasswordConfirm.BackColor = Color.White;
                    lbl_PasswordMatch.Text = "Password matches.";
                    lbl_PasswordMatch.ForeColor = Color.Green;
                }
                else
                {
                    textBox_PasswordConfirm.BackColor = Color.LightPink;
                    lbl_PasswordMatch.Text = "Passwords do not match.";
                    lbl_PasswordMatch.ForeColor = Color.Red;
                }
            }
            // Check if password meets requirements


            isReadyToEncrypt();

        }

        private void isReadyToEncrypt()
        {
            bool isReady = false;

            if (ValidatePassword() && MatchPassword() && File.Exists(txt_FilePath.Text))
                if (new[] { "SHA1", "SHA256", "SHA512" }.Contains(comboBox_HashAlgo.Text))
                    if (new[] { "3DES", "AES128", "AES256" }.Contains(comboBox_EncAlgo.Text))
                        isReady = true;


            btn_Encrypt.Enabled = isReady;
            if (isReady)
                btn_Encrypt.BackColor = Color.LightBlue;
            else
                btn_Encrypt.BackColor = Color.LightGray;

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

        private bool MatchPassword()
        {

            if (textBox_Password.Text != textBox_PasswordConfirm.Text)
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

            isReadyToEncrypt();
        }

        private void btn_DecryptTab_Click(object sender, EventArgs e)
        {


            DecryptForm decryptForm = Application.OpenForms.OfType<DecryptForm>().FirstOrDefault();

            if (decryptForm == null)
            {
                // Create a new instance of decryptForm if it doesn't exist
                decryptForm = new DecryptForm();
                decryptForm.FormClosed += (s, args) => this.Show(); // Show Form1 when decryptForm is closed
                decryptForm.Show();
                this.Hide();
            }
            else
            {
                // Show the existing instance of decryptForm if it exists
                decryptForm.Show();
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

        private void img_PwdConfirmVisible_Click(object sender, EventArgs e)
        {
            img_PwdConfirmHidden.Visible = true;
            img_PwdConfirmVisible.Visible = false;
            textBox_PasswordConfirm.UseSystemPasswordChar = false;
        }

        private void img_PwdConfirmHidden_Click(object sender, EventArgs e)
        {
            img_PwdConfirmHidden.Visible = false;
            img_PwdConfirmVisible.Visible = true;
            textBox_PasswordConfirm.UseSystemPasswordChar = true;
        }

        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            txt_FilePath.Clear();
            comboBox_EncAlgo.SelectedIndex = 0;
            comboBox_HashAlgo.SelectedIndex = 0;
            textBox_Password.Clear();
            lbl_PasswordValidation.Text = String.Empty;
            textBox_PasswordConfirm.Clear();
            lbl_PasswordMatch.Text = String.Empty;
            img_PwdConfirmHidden.Visible = false;
            img_PwdConfirmVisible.Visible = true;
            textBox_PasswordConfirm.UseSystemPasswordChar = true;
            img_PwdHidden.Visible = false;
            img_PwdVisible.Visible = true;
            textBox_Password.UseSystemPasswordChar = true;
            lbl_EncProgressReport.Text = string.Empty;
        }

    }
}