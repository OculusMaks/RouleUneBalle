using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe gérant les objets dépassant de la plateforme
public class OutOfBoundManager : MonoBehaviour
{
    // Si un objet avec un collider et un rigidbody franchit la zone, on replace l'objet à l'origine
    private void OnTriggerEnter(Collider other)
    {
        // "other" désigne l'autre objet entré en contact avec le présent GameObject (la frontière)
        // On fait une transformation de position pour placer l'objet à l'origine, au-dessus de la plateforme
        other.transform.position = new Vector3(0f, 4f, 0f);
    }

}
