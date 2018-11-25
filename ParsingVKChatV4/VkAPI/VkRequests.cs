using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using xNet;

namespace ParsingVKChatV4.VkAPI
{
    class VkRequests
    {
        string _Token = null;

        bool Autorize = false;

        public VkRequests()
        {
            getTokenFromFile();
            if(!string.IsNullOrEmpty(_Token))
            {
                Autorize = true;
            }
        }

        public string Authorization(string APPID, string scope)
        {
            using (var req = new HttpRequest())
            {
                string Request = String.Format("https://oauth.vk.com/authorize?client_id={0}&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope={1}&response_type=token&v=5.86&state=123456", APPID, scope).ToString();
                return Request;
            }
        }

        public List<string> MessagesGetHistory(string ChatID,ref int Count, int offset)
        {
            HttpRequest req = new HttpRequest();
            string sourceResponce = null;
            string Request = String.Format("https://api.vk.com/method/messages.getHistory?&peer_id={0}&count=200&offset={1}&rev=1&access_token={2}&v=5.87", ChatID, Convert.ToString(offset), _Token);
            WebRequest request = WebRequest.Create(Request);
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    sourceResponce = reader.ReadToEnd();
                    reader.Close();
                }
                response.Close();
            }
            if(Count == 0)
            {
                Count = ResponseProcessing.GetCount(sourceResponce.Split(','));
            }
            return ResponseProcessing.GetMessageFields(sourceResponce.Split(','));
        }

        public string GetNameByIDs(string UserId)
        {
            HttpRequest req = new HttpRequest();
            string sourceResponce = null;
            string Request = String.Format("https://api.vk.com/method/users.get?&user_ids={0}&access_token={1}&v=5.87", UserId, _Token);
            WebRequest request = WebRequest.Create(Request);
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    sourceResponce = reader.ReadToEnd();
                    reader.Close();
                }
                response.Close();
            }
            return ResponseProcessing.GetUserName(sourceResponce.Split(','));
        }

        public List<string> GetMembersID(string ChatID)
        {
            HttpRequest req = new HttpRequest();
            string sourceResponce = null;
            string Request = String.Format("https://api.vk.com/method/messages.getConversationMembers?&peer_id=20000000{0}&access_token={1}&v=5.87", ChatID, _Token);
            WebRequest request = WebRequest.Create(Request);
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    sourceResponce = reader.ReadToEnd();
                    reader.Close();
                }
                response.Close();
            }
            return ResponseProcessing.GetUserID(sourceResponce.Split(','));
        }




        void getTokenFromFile()
        {
            if(File.Exists(@"VkData\Token.bin"))
            {
                _Token = File.ReadAllText(@"VkData\Token.bin");
            }
        }
        
        public bool IsAutorize()
        {
            return Autorize;
        }

    }
}
