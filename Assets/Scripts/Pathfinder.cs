using System.Collections.Generic;

public class Pathfinder<T>
{
    readonly Dictionary<T, HashSet<KeyValuePair<T, float>>> map;

    public Pathfinder(Dictionary<T, HashSet<KeyValuePair<T, float>>> map)
    {
        this.map = map;
    }

    public string PathAsString(T from, T to)
    {
        var pathAsString = string.Empty;
        var path = FindPath(from, to);

        if (path != null)
        {
            path.ForEach(t => pathAsString += $"{t} ");
            return pathAsString;
        }
        else
        {
            return "path not possible";
        }
    }

    public List<T> FindPath(T from, T to)
    {
        if (!map.ContainsKey(from) || !map.ContainsKey(to))
        {
            return null;
        }

        var visited = new HashSet<T>();
        var parents = new Dictionary<T, T>();
        var distances = new Dictionary<T, float>();
        var toVisit = new PriorityQueue<T>();

        distances[from] = 0;
        toVisit.Enqueue(from, 0);

        while (toVisit.Count > 0)
        {
            var current = toVisit.Dequeue();
            visited.Add(current);

            if (current.Equals(to))
            {
                break;
            }

            foreach (var neighbor in map[current])
            {
                if (!visited.Contains(neighbor.Key))
                {
                    float newDistance = distances[current] + neighbor.Value; 
                    if (!distances.ContainsKey(neighbor.Key) || newDistance < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = newDistance;
                        toVisit.Enqueue(neighbor.Key, newDistance);
                        parents[neighbor.Key] = current;
                    }
                }
            }
        }

        if (!visited.Contains(to))
        {
            return null;
        }

        var node = to;
        var path = new List<T>();

        while (!node.Equals(from))
        {
            path.Add(node);

            node = parents[node];
        }

        path.Add(from);
        path.Reverse();

        return path;
    }
}