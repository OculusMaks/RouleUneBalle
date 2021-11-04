using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// La classe ForceManager permet de manipuler la force du GameObject sur lequel le script est placé
public class ForceManager : MonoBehaviour
{
    // On déclare nos attributs
    // On veut manipuler la force du GameObject. Seule solution : appeler la classe Rigidbody
    // La variable reste privée car on ne la manipule que dans la présente classe
    private Rigidbody rb;

    // La variable vitesse est déclarée publique pour pouvoir la manipuler sepuis l'éditeur Unity
    public float speed;
    // Variable de puissance de saut
    public float jumpSpeed;
    // Variable pour recuperer la rotation de la camera
    public GameObject cameraPlayer;
    //
    public Text countText;
    private int count;
    public Text winText;
    // On initie nos variables
    void Awake ()
    {
        // On initie notre variable de puissance de saut a 5
        jumpSpeed = 5f;
        // rb est instancié en prenant comme valeur celles du Rigidbody associé au présent GameObject
        rb = GetComponent<Rigidbody>();
        
        // On initie notre variable vitesse de type float à 10
        speed = 10f;
        //
        count = 0;
        SetCountText ();
        winText.text = "";
}
    private void Update()
    {

        // Comme nous sommes obliges de recuperer les Input etant vrais pour 1 frame, nous devons utiliser Update avec le rigidbody pour ne pas louper des frames avec FixedUpdate
        // Clarification : forces continues dans FixedUpdate, one-off force dans Update
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        }
    }
    // Ajouter une force à un gameobject à chaque fixedFrame
    private void FixedUpdate()
    {
        // On récupère les valeurs de nos Input et on les stocke dans des variables de type float
        // Ces variables contiennent donc une valeur pour se diriger sur un axe horizontal ou vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // On créé un vecteur Vector3 contenant les variables sur les axes X et Z récupérés précédemment
        // L'axe Y vertical ne peut pas être modifié par ces variables, donc on laisse sa valeur à 0
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        // Effectue une rotation du vecteur mouvement selon la rotation de la camera autour de l'axe Y
        movement = Quaternion.AngleAxis(cameraPlayer.transform.rotation.eulerAngles.y, Vector3.up) * movement;

        // On fait appel à la méthode AddForce de la classe Rigidbody pour "pousser" notre objet
        // RigidBody est assigné à notre GameObject pour être influencé par la gravité
        // On multiplie le vecteur par une vitesse
        rb.AddForce(movement * speed);
    }
    // Appeler par unity quand notre game objet touchera un collider.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >=17)
        {
            winText.text = "Congrats!";
        }
    }
}
