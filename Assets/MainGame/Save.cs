using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{

    Player_Controller PL;

    public bool TressureGet;

    public bool SlotO1;
    public bool SlotO2;

    public int coin;
    public bool itFree;

    //public float time;

    public float Oxygen = 120;
    public float SaveOxy;

    public int Weight;
    public int MaxWeight = 100;

    public int grCount;




    // Store
    public bool itP1;
    public bool itP2;
    public bool itP3;
    public bool itP4;
    public bool itP5;
    public bool itP6;



    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
        //if (instance != null)
        //{
        //    DontDestroyOnLoad(this);
        //}
        //else
        //{
        //    Destroy(this);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Shop")
        {
            gameManager.instance.TressureGet = TressureGet;
            gameManager.instance.SlotO1 = SlotO1;
            gameManager.instance.SlotO2 = SlotO1;
            gameManager.instance.coin = coin;
            gameManager.instance.itFree = itFree;
            gameManager.instance.Oxygen = Oxygen;
            gameManager.instance.SaveOxy = SaveOxy;
            gameManager.instance.Weight = Weight;
            gameManager.instance.MaxWeight = MaxWeight;
            gameManager.instance.grCount = grCount;
            gameManager.instance.itP1 = itP1;
            gameManager.instance.itP2 = itP2;
            gameManager.instance.itP3 = itP3;
            gameManager.instance.itP4 = itP4;
            gameManager.instance.itP5 = itP5;
            gameManager.instance.itP6 = itP6;
            return;

        }
    }


}

