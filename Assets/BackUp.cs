using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUp : MonoBehaviour
{
    public static BackUp instance;

    [Header("BugFix")]
    [SerializeField] public int coin = gameManager.instance.coin;
    public float Oxygen = gameManager.instance.Oxygen;
    public float SaveOxy = gameManager.instance.SaveOxy;
    public int grCount = gameManager.instance.grCount;

    public bool SlotO1 = gameManager.instance.SlotO1;
    public bool SlotO2 = gameManager.instance.SlotO2;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.instance.coin = coin;
        gameManager.instance.Oxygen = Oxygen;
        gameManager.instance.SaveOxy = SaveOxy;
        gameManager.instance.grCount = grCount;
        gameManager.instance.SlotO1 = SlotO1;
        gameManager.instance.SlotO2 = SlotO2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
