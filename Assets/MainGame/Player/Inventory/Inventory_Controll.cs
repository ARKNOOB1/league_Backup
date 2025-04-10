using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Controll : MonoBehaviour
{
    public GameObject Inventory;

    
    // Start is called before the first frame update
    void Start()
    {
        Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Inventory.SetActive(false);
        }
    }

    public void IvenClose()
    {
        Inventory.SetActive(false);
    }

    
}
