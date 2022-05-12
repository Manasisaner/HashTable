using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{ 
         public class MyMapNode<K, V>//built key value pair hashtable
    {
         private readonly int size;//size of hashtable
        private readonly LinkedList<keyValue<K, V>>[] items;

          public MyMapNode(int size)
            {
            this.size = size;
            //array of linkedlist size is defined
            this.items = new LinkedList<keyValue<K, V>>[size];
            }
         protected int GetArrayPosition(K key) //GetArrayPosition is method and passing key as parameter
        { 
            //hashcode is generated which tells about where the particular key and value will be stored
            int position = key.GetHashCode() % size;//GetHashCode is predifine method,to identifey the hashcode of this particular key
            return Math.Abs(position);//Math.abs function To identify integer value and At what index this purticular keyvalue is present.
        }
          public V Get(K key)//generic method
        {
         
            int position = GetArrayPosition(key);//call method
            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position); 
            foreach (keyValue<K, V> item in linkedList)
            {
      
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
         }
                protected LinkedList<keyValue<K, V>> GetLinkedList(int position)//method and GetLinkedList having return type is Linkedlist keyvalue pair which is define line no13
        {
            //linkedlist contains a data type of keyvalue.
            //position helps to findout the linkedlist in which key value pair will be inserted
            //position is passed into array of items and stored in variable linkedlist with data type as defined below.
            LinkedList<keyValue<K, V>> linkedList = items[position];
        
            if (linkedList == null)
            {
                linkedList = new LinkedList<keyValue<K, V>>();
                //adding a linkedlist in the given array position
                items[position] = linkedList;
            }
            //returning linked list.
            return linkedList;
        }
    }
}
