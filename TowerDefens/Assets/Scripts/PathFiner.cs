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
    Waypoint searchCenter;

    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlock(); 
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        SetAsPath(endWayPoint);
   
        Waypoint previous = endWayPoint.exploredFrom;
        while (previous != startWayPoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }

        SetAsPath(startWayPoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint wayPoint)
    {
        path.Add(wayPoint);
        wayPoint.isPlaceble = false;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWayPoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExlored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWayPoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (var direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                Waypoint neighbour = grid[neighbourCoordinates];
                if (neighbour.isExlored || queue.Contains(neighbour))
                {

                }
                else
                {
                    // neighbour.SetColor(Color.blue);
                    queue.Enqueue(neighbour);
                    neighbour.exploredFrom = searchCenter;
                }
            }
        }
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
}
