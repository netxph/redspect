using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Command
{
    public class Arguments
    {

        public Arguments(string arguments)
        {
            if (arguments.Trim().ToLower() == "exit")
            {
                IsExit = true;
            }
            else
            {
                List<string> commandSplit = new List<string>(Parse(arguments));
                CommandName = commandSplit[0].ToLower();
                commandSplit.RemoveAt(0);
                Parameters = commandSplit.ToArray();
                IsExit = false;
            }
        }

        public string[] Parameters { get; set; }
        public string CommandName { get; private set; }
        public bool IsExit { get; set; }

        public string[] this[int i]
        {
            get { return Parameters; }
        }

        public static string[] Parse(string str)
        {
            if (str == null || !(str.Length > 0)) return new string[0];
            int idx = str.Trim().IndexOf(" ");
            if (idx == -1) return new string[] { str };
            int count = str.Length;
            List<string> list = new List<string>();
            while (count > 0)
            {
                if (str[0] == '"')
                {
                    int temp = str.IndexOf("\"", 1, str.Length - 1);
                    while (str[temp - 1] == '\\')
                    {
                        temp = str.IndexOf("\"", temp + 1, str.Length - temp - 1);
                    }
                    idx = temp + 1;
                }
                if (str[0] == '\'')
                {
                    int temp = str.IndexOf("\'", 1, str.Length - 1);
                    while (str[temp - 1] == '\\')
                    {
                        temp = str.IndexOf("\'", temp + 1, str.Length - temp - 1);
                    }
                    idx = temp + 1;
                }
                string s = str.Substring(0, idx);
                int left = count - idx;
                str = str.Substring(idx, left).Trim();
                list.Add(s.Trim('"'));
                count = str.Length;
                idx = str.IndexOf(" ");
                if (idx == -1)
                {
                    string add = str.Trim('"', ' ');
                    if (add.Length > 0)
                    {
                        list.Add(add);
                    }
                    break;
                }
            }
            return list.ToArray();
        }

    }
}
