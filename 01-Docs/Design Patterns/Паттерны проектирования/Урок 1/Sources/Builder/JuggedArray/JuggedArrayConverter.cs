using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuggedArray
{
    public class JuggedArrayConverter
    {
        private JuggedArray array;
        public JuggedArray Array
        {
            get
            {
                return array;
            }
            set
            {
                this.array = value;
            }
        }
        private JuggedArrayBuilder builder;
        public JuggedArrayBuilder Builder
        {
            get
            {
                return builder;
            }
            set
            {
                this.builder = value;
            }
        }
        public JuggedArrayConverter()
        {
            
        }

        public JuggedArrayConverter(JuggedArray array, JuggedArrayBuilder builder)
        {
            this.array = array;
            this.builder = builder;
        }

        public object Convert() 
        {
            // инициализировать построение
            builder.Initialize();
            // начать построения
            builder.Start();
            for (int r = 0; r < this.array.RowCount(); ++r) {
                // начать новую строку массива
                builder.StartRow();
                for(int c = 0; c < this.array.RowSize(r); ++c){
                    // добавить элемент массива
                    builder.AddItem(array[r, c]);
                }
                // завершить строку массива
                builder.FinishRow();
            }
            // завершить построение
            builder.Finish();
            // получить результат построения
            return builder.Result();
        }
    }
}