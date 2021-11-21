using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletteManager : MonoBehaviour
{
    //Fonction D'activation Deactivation a partir de l'inspecteur. Appeler par le bouton UI du canva dans l'action "On Clic()".
     public void ActivateDeactivate()
    {
        bool isActive = this.gameObject.activeSelf;
        this.gameObject.SetActive(!isActive);
    }
}
