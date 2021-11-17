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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FireCamp")
        {
            StartCoroutine(MakeSound());
        }
    }

    // la coroutine MakeSound joue le son 1, attend 4s, puis joue le son 2
    private IEnumerator MakeSound()
    {
        sourceBeep.clip = Ignition;
        sourceBeep.Play(0);
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }



}