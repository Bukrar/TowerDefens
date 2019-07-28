using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFiner : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlock();
        ColorStartAndEnd();
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
