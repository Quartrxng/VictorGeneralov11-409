using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSplit
{
    class Friends
    {
        public static string FriendFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Friends.txt");

        public static Dictionary<string, string[]> FriendsDictionary = new Dictionary<string, string[]>();
        public static void FriendsCreate(string text)
        {
            if (!File.Exists(FriendFile))
                File.Create(FriendFile).Close();
            var friendArray = FileWork.FileRead(FriendFile);
            if (!string.IsNullOrEmpty(text) && !friendArray.Contains(text))
            {
                FileWork.FileWrite(FriendFile, text);
            }
        }
    }
}
