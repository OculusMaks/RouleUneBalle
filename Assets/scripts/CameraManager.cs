using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cette classe met constamment à jour la position de la caméra par rapport à celle du joueur
public class CameraManager : MonoBehaviour
{
    // On veut récupérer le transform du joueur
    // On déclare une variable de type GameObject publique pour instancier le Gameobject du joueur dans l'éditeur
    public GameObject joueur;

    // Méthode pour déplacer la caméra avec le joueur : on calcule la distance entre le joueur et la caméra au début du jeu
    // et on applique cette distance à chaque frame
    // On déclare une variable de type Vector3 privée pour stocker cette distance
    private Vector3 offset;


    // On initie dans Start pour être sûr que les autres GameObjects se soient bien initialisés avant de manipuler leurs positions
    void Start()
    {
        // La distance est calculée en effectuant une différence entre les coordonnées de la caméra (présent GameObject) et celles du joueur
        offset = this.transform.position - joueur.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // On applique la distance initiale entre le joueur et la caméra à chaque frame
        this.transform.position = joueur.transform.position + offset;
    }
}
