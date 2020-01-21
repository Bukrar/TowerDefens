﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExlored = false;
    public Waypoint exploredFrom;
    public bool isPlaceble = true;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
               Mathf.RoundToInt(transform.position.x / gridSize),
               Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceble)
            {
                FindObjectOfType<TowerFactory>().addTower(this);
            }
            else
            {
                print("Limit 5");
            }
        }
    }
}