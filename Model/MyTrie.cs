using System;

namespace MyTrie.Model
{
    public class MyTrie<T>
    {
        private Node<T> Root;
        public int Count { get; set; }
        public MyTrie()
        {
            Root = new Node<T>('\0', default(T),"");
            Count = 1;
        }
        public void Add(string key, T data)
        {
            AddNode(key, data, Root);
        }
        private void AddNode(string key, T data, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if(!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                }
            }
            else 
            {
                var symbol = key[0];
                var subNode = node.TryFind(symbol);
                if (subNode != null)
                {
                    AddNode(key.Substring(1), data, subNode);
                }
                else 
                {
                    var newNode = new Node<T>(key[0], data, node.Prefix + key[0]);
                    node.SubNotes.Add(key[0], newNode);
                    AddNode(key.Substring(1), data, newNode);
                }
            }   
        }
        public void Remove(string key)
        {
            RemoveNode(key, Root);
        }
        private void RemoveNode(string key, Node<T> node)
        {
            if(string.IsNullOrEmpty(key))
            {
                if(node.IsWord)
                {
                    node.IsWord = false;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode!=null)
                {
                    RemoveNode(key.Substring(1), subnode);
                }  
            }
        }
        public bool TrySearch(string key, out T value)
        {
            return SearchNode(key, Root, out value);
        }
        private bool SearchNode(string key, Node<T> node, out T value)
        {
            value = default(T);
            var result = false;
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    value = node.Data;
                    result = true;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    result = SearchNode(key.Substring(1), subnode, out value);
                }
            }
            return result;
        }
    }
}
