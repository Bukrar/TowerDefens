using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTranform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void addTower(Waypoint waypoint)
    {
        int numTowers = towerQueue.Count;
        if (numTowers < towerLimit)
        {
            InstantNewTower(waypoint);
        }
        else
        {
            RemoveTower(waypoint);
        }
    }

    private void InstantNewTower(Waypoint waypoint)
    {
        var newTower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTranform;
        waypoint.isPlaceble = false;

        newTower.baseWayPoint = waypoint;
        waypoint.isPlaceble = false;
        towerQueue.Enqueue(newTower);
    }

    private void RemoveTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();

        oldTower.baseWayPoint.isPlaceble = true;
        newBaseWaypoint.isPlaceble = false;

        oldTower.baseWayPoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
