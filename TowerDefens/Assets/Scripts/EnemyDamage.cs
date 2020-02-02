using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticleSystem;
    [SerializeField] ParticleSystem deathParticleSystem;
    [SerializeField] AudioClip enemyHitAudio;
    [SerializeField] AudioClip enemyDeathAudio;
    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            var fcx = Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
            fcx.Play();
            AudioSource.PlayClipAtPoint(enemyDeathAudio,Camera.main.transform.position);
            Destroy(fcx.gameObject, fcx.main.duration);
            Destroy(this.gameObject);
        }
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticleSystem.Play();
        myAudioSource.PlayOneShot(enemyHitAudio);
    }
}
