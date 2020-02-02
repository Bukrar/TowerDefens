using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int damage = 1;
    [SerializeField] Text text;
    [SerializeField] AudioClip audioClip;

    private void Start()
    {
        text.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
        health = health - damage;
        text.text = health.ToString();
    }
}
