using WindowsApp.MessageBroker;

namespace WindowsApp
{
    internal partial class FormMessanger : Form
    {
        public FormMessanger(String instanceName)
        {
            InitializeComponent();

            lblInstanceName.Text = instanceName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            BrokerProducer.GetProducer().SendMessage(message);
        }

        private void FormMessanger_FormClosing(object sender, FormClosingEventArgs e)
        {
            BrokerProducer.GetProducer().Dispose();
        }
    }
}