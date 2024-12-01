using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Node : MonoBehaviour
{
    public static event Action<Node> OnClicked = delegate { };

    public Vector3 Position => transform.position;
    public IEnumerable<KeyValuePair<Node, float>> Neighbors => neighbors;

    List<KeyValuePair<Node, float>> neighbors = new List<KeyValuePair<Node, float>>();

    void OnMouseDown()
    {
        OnClicked(this);
        transform.DOPunchScale(Vector3.one * 1.1f, 0.175f);
    }

    void OnDrawGizmos()
    {
        foreach (var neighbor in neighbors)
        {
            Debug.DrawLine(Position, neighbor.Key.Position);
            Node neighborNode = neighbor.Key;
            float distance = neighbor.Value;
            Debug.Log($"Neighbor: {neighborNode.name}, Distance: {distance}");
        }
    }

    void Start()
    {
        var collider = GetComponent<Collider2D>();
        var nodes = FindObjectsOfType<Node>();
        var hits = new RaycastHit2D[1];

        foreach (var node in nodes)
        {
            if (node == this) continue;

            var direction = node.Position - this.Position;
            collider.Raycast(direction, hits);
            foreach (var hit in hits)
            {
                if (hit.collider == null) continue;
                if (hit.collider.TryGetComponent<Node>(out var hitNode))
                {
                    float distance = Vector3.Distance(this.Position, node.Position);
                    neighbors.Add(new KeyValuePair<Node, float>(hitNode, distance));
                }
            }
        }

        GetComponentInChildren<Text>().text = name;
    }
}
