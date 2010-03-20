using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers.CycleQueueDef
{
    #region CycleQueue definition

    public class CycleQueue
    {
        #region Private fields

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

        public bool IsEmpty()
        {
            return curSize == 0;
        }

        public bool IsFull()
        {
            return curSize == maxSize;
        }

        public void Push(int a)
        {
            if (!IsFull())
                arr[curSize++] = a; //array start with zero
        }

        public int PopLeft()
        {
            int forReturn = arr[0];

            if (!IsEmpty())
            {
                forReturn = arr[0];
                for (int i = 0; i < curSize - 1; ++i)
                    arr[i] = arr[i + 1];
                arr[curSize - 1] = forReturn;
            }

            return forReturn;
        }

        public int PopRight()
        {
            int forReturn = arr[curSize - 1];

            if (!IsEmpty())
            {
                forReturn = arr[curSize - 1];
                for (int i = curSize - 1; i > 0; --i)
                    arr[i] = arr[i - 1];
                arr[0] = forReturn;
            }

            return forReturn;
        }

        public void Clear()
        {
            curSize = 0;
        }

        public int GetMaxSize()
        {
            return maxSize;
        }

        #endregion
    }

    #endregion
}
