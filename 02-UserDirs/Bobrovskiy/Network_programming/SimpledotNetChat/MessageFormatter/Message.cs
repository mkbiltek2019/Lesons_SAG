using System;
using System.Collections.Generic;

namespace dotNetChatClient
{
    public class Message : IMessage
    { 
        public string UserName
        {
            get;
            set;
        }

        public string SmileName
        {
            get;
            set;
        }//file name

        public string NewUser
        {
            get;
            set;
        }

        public string PrivateChat
        {
            get;
            set;
        }// true - to Friend, false -broadcast     
            
        public string FriendName
        {
            get;
            set;
        }//to whom message will be send by server 

        public string CurrentMessage
        {
            get;
            set;
        }
        private volatile object sync = new object();
        private string splitter = string.Empty;
        private string format = string.Empty;

        public Message()
        {
            lock (sync)
            {
                splitter = "|";
                format = "{0}" + splitter + "{1}" + splitter + "{2}" + 
                         splitter + "{3}" + splitter + "{4}" + splitter + "{5}";

                this.UserName = "none";
                this.SmileName = "none";
                this.NewUser = "none";
                this.PrivateChat = "none";
                this.FriendName = "none";
                this.CurrentMessage = "none";
            }
        }

        public string Serialize(Message message)
        {
            lock (sync)
            {
                string result = string.Format(format,
                                       message.UserName,
                                       message.SmileName,
                                       message.NewUser,
                                       message.PrivateChat,   
                                       message.FriendName,
                                       message.CurrentMessage);
                return result;
            }
        }

        public Message Deserialize(string currentMessage)
        {
            lock (sync)
            {
                Message message = new Message();

                string[] str = currentMessage.Split(splitter.ToCharArray());

                if (str.Length == 6)
                {
                    message.UserName= str[0];
                    message.SmileName= str[1];
                    message.NewUser= str[2];
                    message.PrivateChat= str[3]; 
                    message.FriendName= str[4];
                    message.CurrentMessage = str[5];
                }

                return message;
            }
        }

    }
}
