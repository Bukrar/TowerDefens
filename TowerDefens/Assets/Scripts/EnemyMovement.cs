using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem goalParticle;
    void Start()
    {
        PathFiner pathFiner = FindObjectOfType<PathFiner>();
        var path = pathFiner.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("StartHere");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        selfDestuct();
    }

    private void selfDestuct()
    {
        var fcx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        fcx.Play();
        Destroy(fcx.gameObject, fcx.main.duration);
        Destroy(this.gameObject);
    }
}
