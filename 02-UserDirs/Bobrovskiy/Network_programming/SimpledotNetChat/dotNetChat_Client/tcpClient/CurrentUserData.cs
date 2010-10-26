using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace dotNetChatClient
{
    public static class CurrentUserData
    {
        private static string serverIP = "127.0.0.1";

        public static string ServerIpAddress
        {
            get 
            {
                return serverIP;
            }
            set 
            {
                serverIP = value;
            }
        }

        public static string ServerPort
        {
            get;
            set;
        }

        public static string UserName
        {
            get;
            set;
        }

        public static string SmileImagePath
        {
            get;
            set;
        }

    }//class
}
