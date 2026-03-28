using System;

namespace Task2
{
    class MyDictionary<TKey, TValue>
    {
        private class Entry
        {
            public TKey Key;
            public TValue Value;
            public Entry Next;
        }

        private Entry[] table = new Entry[16];
        private int count;

        private int GetHash(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % table.Length;
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetHash(key);

            Entry newEntry = new Entry { Key = key, Value = value };

            if (table[index] == null)
            {
                table[index] = newEntry;
            }
            else
            {
                newEntry.Next = table[index];
                table[index] = newEntry;
            }
            count++;
        }

        public bool Remove(TKey key)
        {
            int index = GetHash(key);
            Entry current = table[index];
            Entry prev = null;

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    if (prev == null)
                    {
                        table[index] = current.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                    count--;
                    return true;
                }
                prev = current;
                current = current.Next;
            }
            return false;
        }

        public TValue Find(TKey key)
        {
            int index = GetHash(key);
            Entry current = table[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return default(TValue);
        }

        public int Count => count;
    }

    class DictionaryManager<TKey, TValue>
    {
        private MyDictionary<TKey, TValue> dict = new MyDictionary<TKey, TValue>();

        public void Add(string name, TKey key, TValue value)
        {
            dict.Add(key, value);
            Console.WriteLine($"{name}: {key} = {value}");
        }

        public void Remove(string name, TKey key)
        {
            if (dict.Remove(key))
            {
                Console.WriteLine($"{name}: удален ключ {key}");
            }
            else
            {
                Console.WriteLine($"{name}: ключ {key} не найден");
            }
        }

        public void Find(string name, TKey key)
        {
            TValue value = dict.Find(key);
            if (!EqualityComparer<TValue>.Default.Equals(value, default(TValue)))
            {
                Console.WriteLine($"{name}: {key} = {value}");
            }
            else
            {
                Console.WriteLine($"{name}: {key} не найден");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            DictionaryManager<string, int> manager = new DictionaryManager<string, int>();

            manager.Add("user1", "age", 25);
            manager.Add("user2", "id", 1001);
            manager.Add("user3", "score", 95);

            manager.Find("user1", "age");
            manager.Find("user2", "id");
            manager.Find("user4", "name");

            manager.Remove("user1", "age");
            manager.Find("user1", "age");
        }
    }
}