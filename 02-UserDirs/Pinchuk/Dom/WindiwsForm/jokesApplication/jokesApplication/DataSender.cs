using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace jokesApplication
{
    public static class DataSender
    {
        public delegate XElement JokesDataEvent();
        public static JokesDataEvent JokesDataEventHendler;

        public delegate bool StatisticJokesEvent();

        public static StatisticJokesEvent StatisticJokesEventHendler;
    }
}
