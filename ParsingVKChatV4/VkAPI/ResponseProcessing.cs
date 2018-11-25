using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingVKChatV4.VkAPI
{
   public static class ResponseProcessing
   {
        public static List<string> GetMessageFields(string[] JsonResponse)
        {
            List<string> Temp = new List<string>();
            for (int find = 0; find < JsonResponse.Length; find++)
            {
                if(IsExceptionAPI(JsonResponse[find]))
                { return null; }
                if(JsonResponse[find].Contains("items\":[]}}"))
                {
                    Temp.Add("Сообщений нет");
                    return Temp;
                }
                if (JsonResponse[find].Contains("{\"date\":"))
                {
                    DateTime date = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt64(FindNum(JsonResponse[find])));
                    Temp.Add("DATE:"+date.ToShortDateString());
                }
                if (JsonResponse[find].Contains("from_id"))
                {
                    Temp.Add("ID:" + FindNum(JsonResponse[find]));
                }
                if (JsonResponse[find].Contains("text"))
                {
                    if (JsonResponse[find].Trim('\"', 't', 'e', 'x', 't', ':', '\"') != "")
                    {
                        Temp.Add(JsonResponse[find].Trim('\"', 't', 'e', 'x', 't', ':', '\"'));
                    }
                    else
                    {
                        Temp.Add("*******Картинка*******");
                    }
                }
                if ((!JsonResponse[find].Contains("\"")) || !JsonResponse[find].Contains(":"))
                {
                    Temp[Temp.Count - 1] += JsonResponse[find];
                }
            
            }
            return Temp;
        }

        public static string GetUserName(string[] JsonResponse)
        {
            string UserName = null;
            for(int find = 0; find < JsonResponse.Length;find++)
            {
                if (IsExceptionAPI(JsonResponse[find]))
                { return null; }
                if (JsonResponse[find].Contains("first_name"))
                {
                    UserName += JsonResponse[find].Trim('\"', 'f', 'i', 'r', 's', 't', '_', 'n', 'a', 'm', 'e', ':') + " ";
                }
                if (JsonResponse[find].Contains("last_name"))
                {
                    UserName += JsonResponse[find].Trim('\"', 'l', 'a', 's', 't', '_', 'n', 'a', 'm', 'e', ':', '}', ']');
                }
            }
            return UserName;
        }

        public static List<string> GetUserID(string[] JsonResponse)
        {
            List<string> UserIds = new List<string>();
            for(int find = 0; find < JsonResponse.Length; find++)
            {
                if (IsExceptionAPI(JsonResponse[find]))
                { return null; }
                if (JsonResponse[find].Contains("{\"id\":")) 
                {
                    UserIds.Add(FindNum(JsonResponse[find]));
                }
            }
            return UserIds;
        }

        public static int GetCount(string[] JsonResponse)
        {
            for(int i = 0; i < JsonResponse.Length;i++)
            {
                if (JsonResponse[i].Contains("{\"response\":{\"count\":"))
                {
                    return Convert.ToInt32(FindNum(JsonResponse[i]));
                }
            }
            return 0;
        }

        static public string FindNum(string str)
        {
            string Date = null;
            foreach (char num in str)
            {
                if (char.IsDigit(num) == true)
                {
                    Date += num;
                }
            }
            return Date;
        }

        static bool IsExceptionAPI(string ErrorResponse)
        {
            if(ErrorResponse.Contains("{\"error\":{\"error_code)"))
            {
                return true;
            }
            return false;       
               
        }

    }
}
