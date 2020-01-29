using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticleSystem;
    [SerializeField] ParticleSystem deathParticleSystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            var fcx = Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
            fcx.Play();
            Destroy(fcx.gameObject, fcx.main.duration);
            Destroy(this.gameObject);
        }
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticleSystem.Play();
    }
}
