using System;

namespace NameScopeSample
{
    class Program
    {
        static void Main(string[] args)
        {//начало внешнего блока
            { //начало внутреннего блока
                int i = 0;
            } //конец внутреннего блока
            int counter = 0;
            for (; i < 10; i++)/*на этой строке компилятор возвращает ошибку:
                                the name i does not exist in the current context
                                (мия i не существует в текущем контексте)*/
            {
                counter += i;   /*переменная counter, напротив, 
                                 видна во внутреннем блоке*/ 
            }
        }//начало внешнего блока
    }
}
