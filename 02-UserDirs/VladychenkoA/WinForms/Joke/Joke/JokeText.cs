using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Joke
{
    [Serializable]
    class JokeText
    {
        [XmlAttribute("Title")]
        private string _name;
        [XmlAttribute("Content")]
        private string _text;

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public string Text
        {
            set { _text = value; }
            get { return _text; }
        }

        public JokeText()
        {
            _name = "";
            _text = "";
        }

        public JokeText(string n, string t)
        {
            _name = n;
            _text = t;
        }
        public ArrayList JokeTextArL = new ArrayList();
    }
    public class JokesList
    {
        private ArrayList jokeList = new ArrayList();

        public ArrayList JokeList()
        {
           return jokeList ;

        }

        public void LoadXmlFile(string nameFile)
        {
            XElement list = XElement.Load(nameFile);

            IEnumerable<XElement> title =
                from element in list
                    .Elements("Joke")
                    .Elements("Title")
                select element;

            IEnumerable<XElement> content =
                from element in list
                    .Elements("Joke")
                    .Elements("Content")
                select element;

            for (int i = 0; i < title.Count(); i++)
            {
                JokeText jokeText = new JokeText(title.ElementAt(i).Value,content.ElementAt(i).Value);
                jokeList.Add(jokeText);
            }
        }
    }
    //[XmlRoot("_listJkes")]
    //public class JokeList
    //{
    //    private ArrayList _listJokes;

    //    public JokeList()
    //    {
    //        _listJokes = new ArrayList();
    //    }

    //    [XmlElement("joke")]
    //    public JokeText[] Joketexts
    //    {
    //        get
    //        {
    //            JokeText[] jokeTexts = new JokeText[_listJokes.Count];
    //            _listJokes.CopyTo(jokeTexts);
    //            return jokeTexts;
    //        }
    //        set
    //        {
    //            if( value == null) return;
    //            JokeText[] jokeTexts = (JokeText[]) value;
    //            _listJokes.Clear();
    //            foreach (JokeText jokeText in jokeTexts)
    //                _listJokes.Add(jokeText);
    //        }
    //    }

    //    public int AddJokeText(JokeText jokeText)
    //    {
    //        return _listJokes.Add(jokeText);
    //    }
    //}
  

    
}
