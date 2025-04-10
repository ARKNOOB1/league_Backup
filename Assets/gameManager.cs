using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    Player_Controller PL;

    public bool clear;

    public bool TressureGet = false;

    public bool SlotO1;
    public bool SlotO2;

    public bool shopShower = false;

    public int coin;
    public bool itFree;

    public float time;

    public float Oxygen = 120;
    public float SaveOxy;

    public int Weight;
    public int MaxWeight = 100;

    public int grCount;
    


    // Store
    public bool itP1 = false;
    public bool itP2 = false;
    public bool itP3 = false;
    public bool itP4 = false;
    public bool itP5 = false;
    public bool itP6 = false;


    private void Awake()
    {
        instance = this;
        if (instance != null)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!clear)
        {
            if (SceneManager.GetActiveScene().name == "MainGame")
            {
                Oxygen -= Time.deltaTime;
                time += Time.deltaTime;
            }
        }
        
    }
    

}
