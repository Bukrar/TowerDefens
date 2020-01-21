using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    public void addTower(Waypoint waypoint)
    {
        var towers = FindObjectsOfType<Tower>();
        int numTowers = towers.Length;
        if (numTowers < towerLimit)
        {
            Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
            waypoint.isPlaceble = false;
        }
        else
        {
            RemoveTower();
        }
    }

    private static void RemoveTower()
    {
        print("Limit 5");
       
    }
}
