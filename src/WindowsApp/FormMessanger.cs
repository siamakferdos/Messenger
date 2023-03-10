namespace WindowsApp
{
    public partial class FormMessanger : Form
    {
        public FormMessanger(String instanceName)
        {
            InitializeComponent();

            lblInstanceName.Text = instanceName;
        }
    }
}