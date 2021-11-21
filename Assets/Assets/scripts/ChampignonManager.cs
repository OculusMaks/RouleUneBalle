using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampignonManager : MonoBehaviour
{
    public AudioClip beep1;
    public AudioClip beep2;
    private AudioSource sourceBeep;

    // Start is called before the first frame update
    void Start()
    {
        sourceBeep = this.GetComponent<AudioSource>();
    }

    // si la collision est faite avec le joueur, démarrer la coroutine MakeSound
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(MakeSound());
        }
    }

    // la coroutine MakeSound joue le son 1, attend 4s, puis joue le son 2
    private IEnumerator MakeSound()
    {
        sourceBeep.clip = beep1;
        sourceBeep.Play(0);
        yield return new WaitForSeconds(4f);
        sourceBeep.clip = beep2;
        sourceBeep.Play(0);

    }
}
