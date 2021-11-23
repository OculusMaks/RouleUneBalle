using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public AudioClip Ignition;
    private AudioSource sourceBeep;

    // Start is called before the first frame update
    void Start()
    {
        sourceBeep = this.GetComponent<AudioSource>();
    }

    // si la collision est faite avec le joueur, démarrer la coroutine MakeSound
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Feu Detecter");
        if (other.gameObject.CompareTag("FireCamp"))
        {
             this.gameObject.SetActive(false);
        }
    }



}