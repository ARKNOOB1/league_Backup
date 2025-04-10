using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Controll : MonoBehaviour
{
    public bool canOpen;

    public GameObject box;
    public Animator ani;
    public Sprite opend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ani.Play("Open");
                SpriteRenderer sp = box.GetComponent<SpriteRenderer>();
                sp.sprite = opend;
                gameManager.instance.TressureGet = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            canOpen = false;
        }
    }
}
