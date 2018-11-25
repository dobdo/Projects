using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParsingVKChatV4.Forms
{
    using ParsingVKChatV4.VkAPI;
    public partial class AuthForm : Form
    {
        VkRequests Vkontakte = new VkRequests();
        public AuthForm()
        {
            InitializeComponent();
            GetToken.DocumentCompleted += GetToken_DocumentCompleted;
            GetToken.Navigate(Vkontakte.Authorization("6688009", "offline,messages"));
        }
        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }
        private void GetToken_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (GetToken.Url.ToString().IndexOf("access_token=") != -1)
            {
                GetUserToken();
            }
        }
        private void GetUserToken()
        {
            char[] Symbols = { '=', '&' };
            string[] URL = GetToken.Url.ToString().Split(Symbols);
            System.IO.File.WriteAllText(@"VkData\Token.bin", URL[1]);
            Visible = false;
        }
        private void GetToken_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e) { }
    }

}

