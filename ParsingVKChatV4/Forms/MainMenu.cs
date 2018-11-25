using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace ParsingVKChatV4.Forms
{
    using ParsingVKChatV4.VkAPI;
    public partial class MainMenu : Form
    {
        readonly string TokenPath = @"VkData\Token.bin";
        VkRequests Vkontakte;
        
        public MainMenu()
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(File.ReadAllText(TokenPath)))
            {
                autorizationMenuSet();
            }
            else
            {
                MainMenuButtonSet();
            }            
        }

        private void AuthButton_Click(object sender, EventArgs e)
        {
            AuthForm Auth = new AuthForm();
            Auth.Show();
            MainMenuButtonSet();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            Vkontakte = new VkRequests();
            if (!(string.IsNullOrEmpty(ChatIDField.Text)) && (Vkontakte.IsAutorize()))
            {
                if (File.Exists(@"VkData\" + ChatIDField.Text + "Messages.txt") && !(string.IsNullOrEmpty(File.ReadAllText(@"VkData\" + ChatIDField.Text + "Messages.txt"))))
                {
                    GetMissingMessages();
                    ChatIDField.ReadOnly = true;
                    ChooseNewChatButton.Visible = true;
                }
                else
                {
                    GetAllMessages();
                    ChatIDField.ReadOnly = true;
                    ChooseNewChatButton.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Что бы построить график необходимо заполнить ID чата", "Не заполнено поле чат ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DrawGraphButton_Click(object sender, EventArgs e)
        {
            GraphMenuSet();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainMenuButtonSet();
            ChatIDField.ReadOnly = false;
        }

        private void AllTimeGraphButton_Click(object sender, EventArgs e)
        {
            if ((File.Exists(@"VkData\" + ChatIDField.Text + "Messages.txt")) && (!string.IsNullOrEmpty(File.ReadAllText(@"VkData\" + ChatIDField.Text + "Messages.txt"))))
            {
                if (!string.IsNullOrEmpty(ChatIDField.Text))
                {
                    GraphForm Graph = new GraphForm(ChatIDField.Text);
                    Graph.Show();
                }
                else
                {
                    MessageBox.Show("Что бы построить график необходимо заполнить ID чата", "Не заполнено поле чат ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Сначала необходимо выгрузить сообщения", "Сообщения данного чата не выгружены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ChooseNewChatButton_Click(object sender, EventArgs e)
        {
            ChatIDField.ReadOnly = false;
            MainMenuButtonSet();
            ChooseNewChatButton.Visible = false;
        }

        void GetAllMessages()
        {
            int Pause = 200;
            List<string> Temp = new List<string>();
            int Count = 0;
          
                for (int offset = 0; ; offset += 200)
                {
                    if (offset == Pause)
                    {
                        Thread.Sleep(1000);
                        Pause += 200;
                    }
                    Temp = Vkontakte.MessagesGetHistory("20000000"+ChatIDField.Text,ref Count,offset);
                if (Temp.Count == 0)
                {
                    MessageBox.Show("Ошибка возврата сообщений проверьте корректность ID Чата", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                if (offset >= Count)
                    {
                        File.AppendAllText(@"VkData\" + ChatIDField.Text + "Messages.txt","COUNT: " + Convert.ToString(Count));
                        label3.Visible = true;
                        break;
                    }
                    DownloadProgress.Maximum = Count;
                    DownloadProgress.Value = offset;
                    File.AppendAllLines(@"VkData\" + ChatIDField.Text + "Messages.txt", Temp);
                
                }
           
        }
        
        void GetMissingMessages()
        {
            int Pause = 200;
            string[] Messages = File.ReadAllLines(@"VkData\" + ChatIDField.Text + "Messages.txt");
            List<string> Temp = new List<string>();
            int StartOffset = GetStartOffset();
            int Count = 0;
                for (int offset = StartOffset; ; offset += 200)
                {
                    if (offset == Pause)
                    {
                        Thread.Sleep(1000);
                        Pause += 200;
                    }
                    Temp = Vkontakte.MessagesGetHistory("20000000" + ChatIDField.Text,ref Count, offset);
                
                if (Temp.Count == 0)
                {
                    MessageBox.Show("Ошибка возврата сообщений проверьте корректность ID Чата","ОШИБКА",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    File.AppendText("COUNT: " + Convert.ToString(Count));
                    break;
                }
                if (offset >= Count)
                    {
                        File.AppendAllText(@"VkData\" + ChatIDField.Text + "Messages.txt", "COUNT: " + Convert.ToString(Count));
                        label3.Visible = true;
                        break;
                    }
                if (Temp.Contains("Сообщений нет"))
                {
                    MessageBox.Show("Новых сообщений нет", "Все сообщения выгружены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                DownloadProgress.Maximum = Count;
                    DownloadProgress.Value = offset;
                   File.AppendAllLines(@"VkData\" + ChatIDField.Text + "Messages.txt", Temp);
                }
        }

        int GetStartOffset()
        {
            string[] Temp = File.ReadAllLines(@"VkData\" + ChatIDField.Text + "Messages.txt");
            int startOffset = Convert.ToInt32( Temp[Temp.Length - 1].Trim('C', 'O', 'U', 'N', 'T', ':'));
            Temp[Temp.Length - 1] = null;
            File.WriteAllLines(@"VkData\" + ChatIDField.Text + "Messages.txt",Temp);
            return startOffset;
        }


        void autorizationMenuSet()
        {
            AuthButton.Visible = true;
            ChatIDField.Visible = false;
            DownloadButton.Visible = false;
            DrawGraphButton.Visible = false;
            BackButton.Visible = false;
            AllTimeGraphButton.Visible = false;
            PeriodGraphButton.Visible = false;
            ToDateField.Visible = false;
            SinceDateField.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            DownloadProgress.Visible = false;
        }
        void MainMenuButtonSet()
        {
            AuthButton.Visible = false;
            ChatIDField.Visible = true;
            DownloadButton.Visible = true;
            DrawGraphButton.Visible = true;
            BackButton.Visible = false;
            AllTimeGraphButton.Visible = false;
            PeriodGraphButton.Visible = false;
            ToDateField.Visible = false;
            SinceDateField.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            DownloadProgress.Visible = true;
        }
        void GraphMenuSet()
        {
            AuthButton.Visible = false;
            ChatIDField.Visible = false;
            DownloadButton.Visible = false;
            DrawGraphButton.Visible = false;
            BackButton.Visible = true;
            AllTimeGraphButton.Visible = true;
            PeriodGraphButton.Visible = true;
            ToDateField.Visible = true;
            SinceDateField.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            DownloadProgress.Visible = false;
        }




        private void PeriodGraphButton_Click(object sender, EventArgs e)
        {
            GraphForm Graph = new GraphForm(ChatIDField.Text, SinceDateField.Text, ToDateField.Text);
            Graph.Show();
        }
    }
}
