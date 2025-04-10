using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMover : MonoBehaviour
{
    public Transform endPoint;
    public bool isInside;
    public Rigidbody2D Player;

    
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
                Player.transform.position = endPoint.transform.position;
                //for (int i = 0; i < itemList.Count; i++)
                //{
                //    gameManager.instance.coin += itemList[i].gameObject.GetComponent<ItemData>().itemPrice;
                //    gameManager.instance.Weight -= itemList[i].gameObject.GetComponent<ItemData>().itemWeight;
                //    Debug.Log(itemList[i]);
                //    itemList[i].IsDestroyed();
                //}
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
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
