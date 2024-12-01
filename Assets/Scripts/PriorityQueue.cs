using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    private List<KeyValuePair<T, float>> elements = new List<KeyValuePair<T, float>>();

    public int Count => elements.Count;

    public void Enqueue(T item, float priority)
    {
        elements.Add(new KeyValuePair<T, float>(item, priority));
        SortQueue();
    }

    public T Dequeue()
    {
        var bestItem = elements[0].Key;
        elements.RemoveAt(0);
        return bestItem;
    }

    private void SortQueue()
    {
        elements.Sort((x, y) => x.Value.CompareTo(y.Value));  // Sort based on priority
    }
}
