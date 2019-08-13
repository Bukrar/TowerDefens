using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFiner : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
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
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach (var direction in directions)
        {
            Vector2Int exp = startWayPoint.GetGridPos() + direction;
            try
            {
                grid[exp].SetColor(Color.blue);
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
