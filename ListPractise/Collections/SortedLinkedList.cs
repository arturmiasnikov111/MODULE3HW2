using System;
using System.Collections.Generic;

namespace ListPractise.Collections
{
    public class SortedLinkedList<T>: LinkedList<T> where T: IComparable
    {
        public void AddSorted(T value)
        {

            if (Count < 1)
            {
                AddFirst(value);
            }
            else if (value.CompareTo(First.Value) == -1)
            {
                AddFirst(value);
            }
            else if (value.CompareTo(Last.Value) == 1)
            {
                AddLast(value);
            }
            else if (value.CompareTo(Last.Value) == 0)
            {
                AddLast(value);
            }
            else if (value.CompareTo(First.Value) == 0)
            {
                AddFirst(value);
            }
            else
            {
                var current = First;
                while (true)
                {
                    current = current.Next;
                    if (current == null || value.CompareTo(current.Value) == -1)
                    {
                        break;
                    }
                }

                if (current == null)
                {
                    AddLast(value);
                }
                else
                {
                    AddBefore(current, value);
                }
            }
        }
    }
}