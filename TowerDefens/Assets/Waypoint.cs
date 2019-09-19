﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    public bool isExlored = false;
    public Waypoint exploredFrom;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
               Mathf.RoundToInt(transform.position.x / gridSize) ,
               Mathf.RoundToInt(transform.position.z / gridSize) 
            );
    }

    public void SetColor(Color color)
    {
        MeshRenderer topMMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMMeshRenderer.material.color = color;
    }
}
