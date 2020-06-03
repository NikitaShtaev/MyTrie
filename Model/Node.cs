

using System.Collections.Generic;

namespace MyTrie.Model
{
    public class Node<T>
    {
        public char Symbol { get; set; }
        public T Data { get; set; }
        public bool IsWord { get; set; }
        public string Prefix { get; set; }
        public Dictionary<char, Node<T>> SubNotes { get; set; }
        
        private Node(string prefix)
        {
            Prefix = prefix;
        }
        public Node(char symbol, T data, string prefix)
        {
            Data = data;
            Prefix = prefix;
            Symbol = symbol;
            SubNotes = new Dictionary<char, Node<T>>();
        }
        public override string ToString()
        {
            return $"{Data} [{SubNotes.Count}] ({Prefix})";
        }
        public override bool Equals(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.Equals(item);
            }
            else
            {
                return false;
            }
        }
        public Node<T> TryFind(char symbol)
        {
            if (SubNotes.TryGetValue(symbol, out Node<T> value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }
        
    }
}
