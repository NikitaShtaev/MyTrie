using MyTrie.Model;
using System;

namespace MyTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new MyTrie<int>();
            trie.Add("hello", 50);
            trie.Add("hell", 100);
            trie.Add("peace", 200);
            trie.Add("peacefull", 50);
            trie.Remove("hell");
            Search(trie, "hello");
            Search(trie, "hell");
            Search(trie, "peace");
            Search(trie, "peacefull");
            Console.ReadLine();
        }

        private static void Search(MyTrie<int> trie, string word)
        {
            if(trie.TrySearch(word, out int value))
            {
                Console.WriteLine(word + " " + value);
            }
            else
            {
                Console.WriteLine("Not found: " + word);
            }
        }
    }
}
