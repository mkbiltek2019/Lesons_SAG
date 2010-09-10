using System;

namespace FileSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Searcher searcher = new Searcher("*.txt");
                searcher.DoSearch();

                while (!searcher.IsCompleted) { };

                Console.WriteLine("Files count: {0}", searcher.FileCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error has occured: {0}", e.Message);
            }
            catch
            {
                Console.WriteLine("Unknowne error has occured.");
            }
        }
    }
}
