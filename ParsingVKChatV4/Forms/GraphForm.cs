using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace ParsingVKChatV4.Forms
{
    using ParsingVKChatV4.VkAPI;
    public partial class GraphForm : Form
    {
      
        VkRequests Vkontakte = new VkRequests();
        List<string> UserStats = new List<string>();
        string Chat = null;
        public GraphForm(string ChatID)
        {
            Chat = ChatID;
            InitializeComponent();
            chart1.Visible = true;
            SetChartData(ref UserStats);
            BildChart();
        }

      
        void SetChartData(ref List<string> UserStat)
        {
            List<string> AllMessages = GetMessages();

            UserStat = GetMembersNames(GetMembersID());

            for (int i = 0; i < UserStat.Count; i++)
            {
                int Count = 0;
                foreach (var UserID in AllMessages)
                {
                    if (UserID.Contains("ID:"))
                    {
                        if (ResponseProcessing.FindNum(UserStat[i]) == UserID.Trim('I', 'D', ':'))
                        {
                            Count++;
                        }
                    }
                }
                UserStat[i] += "," + Convert.ToString(Count);
            }
        }

        void BildChart()
        {   
            for(int i = 0;i<UserStats.Count;i++)
            {
                chart1.Series.Add(UserStats[i]);
                chart1.Series[UserStats[i]].ChartType = SeriesChartType.Column;
                chart1.Series[UserStats[i]].Points.AddY(Convert.ToInt64(UserStats[i].Split(',')[1]));
                chart1.Series[UserStats[i]].ChartArea = "ChartArea1";
                chart1.Series[i].Name = UserStats[i].Split('(')[0];
            }
        }

        List<string> GetMessages()
        {
            List<string> Temp = new List<string>();
            if ((File.Exists(@"VkData\" + Chat + "Messages.txt")&&(!string.IsNullOrEmpty(File.ReadAllText(@"VkData\" + Chat + "Messages.txt")))))
            {
                Temp.AddRange(File.ReadAllLines(@"VkData\" + Chat + "Messages.txt"));
            }
            return Temp;
        }

        List<string> GetMembersID()
        {
            List<string> temp = new List<string>();
            if (Vkontakte.IsAutorize())
            {
                temp =  Vkontakte.GetMembersID(Chat);
            }
            return temp;
        }

        List<string> GetMembersNames(List<string> MembersID)
        {
            int pause = 3;
            List<string> Temp = new List<string>();
            if(Vkontakte.IsAutorize())
            {
               for(int i =0;i<MembersID.Count;i++)
               {
                    if(i==pause)
                    {
                        pause += 3;
                        Thread.Sleep(1000);
                    }
                    Temp.Add(Vkontakte.GetNameByIDs(MembersID[i])+"("+ MembersID[i] +")");
               }
            }
            return Temp;
        }

        private void GraphForm_Load(object sender, EventArgs e)
        {

        }
    }
}
