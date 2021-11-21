using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
    //Instantie les clips audios qui seront utiliser dans le script.
{
    public AudioClip LifeUp;
    public AudioClip Mastiquer;
    private AudioSource sourceBeep;

    // Start is called before the first frame update / Va chercher le son demander.
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

    // la coroutine MakeSound joue le son 1, attend 1s, puis joue le son 2.Un second arret de 0.5 seconde permet d'avoir
    // une transition plus fluid avant de desactiver l'objet!
    private IEnumerator MakeSound()
    {
        sourceBeep.clip = Mastiquer;
        sourceBeep.Play(0);
        yield return new WaitForSeconds(1f);
        sourceBeep.clip = LifeUp;
        sourceBeep.Play(0);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }



}