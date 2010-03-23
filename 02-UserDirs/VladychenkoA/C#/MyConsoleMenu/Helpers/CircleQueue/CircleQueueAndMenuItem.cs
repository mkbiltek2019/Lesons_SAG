using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers.CircleQueueAndMenuItem
{
    #region CnsoleMenuItem definition

    public class ConsoleMenuItem
    {
        #region Properties

        public string Description
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }

        #endregion 

        #region Constructors

        public ConsoleMenuItem() :
            this(string.Empty, string.Empty, false)
        { }

        public ConsoleMenuItem(string description, string key, bool visible)
        {
            Description = description;
            Key = key;
            Visible = visible;
        }

        #endregion 

        #region Overrides

        public override string ToString()
        {
            return string.Format("{0}.  {1}", Key, Description);
        }

        #endregion 
    }

    #endregion 

    #region CycleOueue definition

    public class CycleQueue
    {
        #region Private Fields

        private int[] arr;
        private int maxSize = 0;
        private int curSize = 0;

        #endregion

        #region Public methods

        public CycleQueue(int maxSize)
        {
            if (maxSize > 0)
            {
                this.maxSize = maxSize;
            }
            else
                maxSize = 0;

            arr = new int[maxSize];
            curSize = 0;
        }
        public bool IsEmmty()
        {
            return curSize == 0;
        }

        public bool IsFull()
        {
            return curSize == maxSize;
        }

        public int PopLeft()
        {
            int forReturn = arr[0];

            if (!IsEmmty())
            {
                forReturn = arr[0];
                for (int i = 0; i < curSize; i++)
                    arr[i] = arr[i + 1];
                arr[curSize - 1] = forReturn;
            }
            return forReturn;
        }

        public int PopRight()
        {
            int forReturn = arr[curSize - 1];
            if (!IsEmmty())
            {
                forReturn = arr[curSize - 1];
                for (int i = curSize - 1; i > 0; i--)
                    arr[i] = arr[i - 1];
                arr[0] = forReturn;
            }
            return forReturn;
        }

        public int GetMaxSize()
        {
            return maxSize;
        }

        public void Clear()
        {
            curSize = 0;
        }

        #endregion
    }

    #endregion 
}
