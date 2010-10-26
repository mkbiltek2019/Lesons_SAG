using System;

namespace dotNetChatClient
{
    public interface IMessage
    {
        string PrivateChat
        {
            get;
            set;
        }// true - to Friend, false -broadcast

        string SmileName
        {
            get;
            set;
        }//file name

        string UserName
        {
            get;
            set;
        }

        string CurrentMessage
        {
            get;
            set;
        }

        string FriendName
        {
            get;
            set;
        }//to whom message will be send by server 
    }
}
