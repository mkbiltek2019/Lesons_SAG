using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace lesson_12_winform
{
    public struct titleContent
    {
        public string title;
        public string content;

        public titleContent(string titl, string cont)
        {
            title = titl;
            content = cont;
        }
    }

    public class JokesReader
    {
        private ArrayList jokeList = new ArrayList();

        public ArrayList JokeList
        {
            get
            {
                return jokeList;
            }
        }

        public void LoadJokesFromFile(string fileName)
        {
            XElement jList = XElement.Load(fileName);

            IEnumerable<XElement> jokeContent =
                from el in jList
                    .Elements("joke")
                    .Elements("content")
                select el;

            IEnumerable<XElement> jokeTitle =
                from el in jList
                    .Elements("joke")
                    .Elements("title")
                select el;

            for (int i = 0; i < jokeContent.Count(); i++)
            {
                titleContent tt = new titleContent(jokeTitle.ElementAt(i).Value,
                               jokeContent.ElementAt(i).Value);
                jokeList.Add(tt);
            }
        }

    }
}
