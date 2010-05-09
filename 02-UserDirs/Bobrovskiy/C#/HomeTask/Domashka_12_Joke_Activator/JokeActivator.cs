using System;
using System.Collections;

namespace lesson_12_winform
{
    public class JokeActivator
    {
        public int numberOfUglyJokes
        {
            get;
            set;
        }

        public int numberOfCoolJokes
        {
            get;
            set;
        }

        public titleContent GetSingleJoke(ArrayList jokeList)
        {
            if (jokeList.Count > 0)
            {
                Random random = new Random();
                int value = random.Next(0, jokeList.Count);
                titleContent result = (titleContent)jokeList[value];
                jokeList.RemoveAt(value);

                return result;
            }

            return new titleContent(string.Empty, string.Empty);
        }

    }
}
