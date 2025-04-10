using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float curtime;
    public float cooltime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(curtime > 0)
        {
            curtime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(curtime <= 0)
        {
            if (col.tag == "Player")
            {
                col.GetComponent<Player_Controller>().PL_Damaged(1);
            }
            curtime = cooltime;
        }
        

    }
}
