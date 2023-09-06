namespace EncryptionGenie
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }



        public void UpdateProgress(int value)
        {
            // Invoke the progress bar control on the form
            // to update it on the UI thread
            progressBar.Invoke(new Action(() => progressBar.Value = value));
        }
        public void UpdateEncProgress(string value)
        {
            // Invoke the progress bar control on the form
            // to update it on the UI thread
            lbl_EncProgressReport.Invoke(new Action(() => lbl_EncProgressReport.Text = value));
        }
    }
}
