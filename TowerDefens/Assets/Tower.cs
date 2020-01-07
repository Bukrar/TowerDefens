using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    [SerializeField] float attactRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;
    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void FireEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, this.gameObject.transform.position);
        if (distanceToEnemy <= attactRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
