using CAPIATL_Proxy;

namespace CAPIATL_Client
{
    public partial class Form1 : Form
    {
        private CAPIATL_API m_API;
        private CAPIATL_API API
        {
            get
            {
                if(m_API == null)
                {
                    m_API = new CAPIATL_API();
                }
                return m_API;
            }
        }

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strSDate = "";
            String strEDate = "";
            String strMsg = "";
            String strMsgCode = "";
            strMsgCode = API.GetCertStatus("F123357900", out strSDate, out strEDate, out strMsg);

            if (strMsgCode == "000")
            {
                MessageBox.Show("起始日：" + strSDate + "結束日：" + strEDate);
            }
            else
            {
                MessageBox.Show($"{DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff")}:{strMsgCode}:{strMsg}");
            }
        }
    }
}
