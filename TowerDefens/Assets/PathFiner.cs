using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFiner : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    bool isRunning = true;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlock();
        ColorStartAndEnd();
        PathFind();
    }

    private void PathFind()
    {
        queue.Enqueue(startWayPoint);
        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from" + searchCenter);
            if (searchCenter == endWayPoint)
            {
                print("stop!!!!");
                isRunning = false;
            }
            ExploreNeighbours(searchCenter);
            searchCenter.isExlored = true;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning) { return; }
        foreach (var direction in directions)
        {
            Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
            try
            {
                Waypoint neighbour = grid[neighbourCoordinates];
                if (neighbour.isExlored || queue.Contains(neighbour))
                {

                }
                else
                {
                    neighbour.SetColor(Color.blue);
                    queue.Enqueue(neighbour);
                    print("Queueing" + neighbour);
                }
            }
            catch { }
        }
    }

    private void ColorStartAndEnd()
    {
        startWayPoint.SetColor(Color.black);
        endWayPoint.SetColor(Color.red);
    }

    private void LoadBlock()
    {
        var wayPoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in wayPoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                print("LAP");
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
