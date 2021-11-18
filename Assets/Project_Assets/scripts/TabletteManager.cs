using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletteManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void ActivateDeactivate()
    {
        bool isActive = this.gameObject.activeSelf;
        this.gameObject.SetActive(!isActive);
    }
}
