using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera Pl_Camera;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pl_Camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
    }
}
