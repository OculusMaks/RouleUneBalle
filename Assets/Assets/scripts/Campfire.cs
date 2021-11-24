using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{

    public AudioClip Ignition;
    public AudioSource sourceBeep;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Fire();
        }
    }
    private void Fire()

        {
        sourceBeep.clip = Ignition;
        sourceBeep.Play(0);
        }
 }
