using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public bool isInside;
    public Rigidbody2D Player;
    Player_Controller pl;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameManager.instance.shopShower = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isInside = true;
            Player = col.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isInside = false;
        }
    }

    
}
