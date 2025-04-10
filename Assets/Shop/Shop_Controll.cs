using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop_Controll : MonoBehaviour
{
    public GameObject Shop;

    public GameObject Rank;

    public Text Coin;

    public GameObject gameClear;

    public Text totalTime;

    public Image Slot1;
    public Image Slot2;
    public Image Slot3;
    public Image Slot4;
    public Image Slot5;
    public Image Slot6;

    public Player_Controller rb;




    // Start is called before the first frame update
    void Start()
    {
        Shop.SetActive(false);
        Rank.SetActive(false);
        gameClear.SetActive(false);
        if (gameManager.instance.TressureGet)
        {
            gameClear.SetActive(true);
            Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.instance.TressureGet && gameManager.instance.shopShower)
        {
            gameClear.SetActive(true);
            Clear();
            gameManager.instance.clear = true;
            gameManager.instance.TressureGet = false;
        }
        Coin.text = "COIN: " + gameManager.instance.coin.ToString();
    }
    void Clear()
    {
        int timeM = (int)gameManager.instance.time / 60;
        int timeS = (int)gameManager.instance.time % 60;
        totalTime.text = "TOTAL TIME: " + timeM.ToString("D2") + ":" + timeS.ToString("D2");
    }
    public void OpenRank()
    {
        Rank.SetActive(true);
    }
    public void CloseRank()
    {
        Rank.SetActive(false);
    }

    public void CloseClear()
    {
        gameClear.SetActive(false);
    }

    public void GameStart()
    {
        gameManager.instance.shopShower = false;
        gameManager.instance.SaveOxy = gameManager.instance.Oxygen;
        gameManager.instance.itFree = false;
        gameManager.instance.TressureGet = false;
    }

    public void ShopOpen()
    {
        Shop.SetActive(true);
    }

    public void ShopClose()
    {
        Shop.SetActive(false);
    }

    // 소형 산소통
    public void Purchase1()
    {
        if (gameManager.instance.itP1 || gameManager.instance.itP2 || gameManager.instance.itP3)
        {
            Debug.Log("이미 구매함");
            Color color = Slot1.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot1.color = color;
            return;
        }
        if (gameManager.instance.itFree)
        {
            Color color = Slot1.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot1.color = color;

            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            gameManager.instance.Oxygen = 180;
            Debug.Log("상품 구매");
            gameManager.instance.itP1 = true;
            return;
        }
        if(gameManager.instance.coin >= 20)
        {
            Color color = Slot1.color;
            if(color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot1.color = color;

            gameManager.instance.coin -= 20;
            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            gameManager.instance.Oxygen = 180;
            Debug.Log("상품 구매");
            gameManager.instance.itP1 = true;
        }
    }

    // 중형 산소통
    public void Purchase2()
    {
        if (gameManager.instance.itP2 || gameManager.instance.itP3)
        {
            Debug.Log("이미 구매함");
            Color color = Slot2.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot2.color = color;
            return;
        }
        if (gameManager.instance.itFree)
        {
            Color color = Slot2.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot2.color = color;

            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            gameManager.instance.Oxygen = 240;
            Debug.Log("상품 구매");
            gameManager.instance.itP2 = true;
            return;
        }
        if (gameManager.instance.coin >= 40)
        {
            Color color = Slot2.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot2.color = color;

            gameManager.instance.coin -= 40;
            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            gameManager.instance.Oxygen = 240;
            Debug.Log("상품 구매");
            gameManager.instance.itP2 = true;
        }
    }

    // 대형 산소통
    public void Purchase3()
    {
        if (gameManager.instance.itP3)
        {
            Debug.Log("이미 구매함");
            Color color = Slot3.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot3.color = color;
            return;
        }
        if (gameManager.instance.itFree)
        {
            Color color = Slot3.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot3.color = color;

            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            gameManager.instance.Oxygen = 320;
            Debug.Log("상품 구매");
            gameManager.instance.itP3 = true;
            return;
        }
        if (gameManager.instance.coin >= 60)
        {
            Color color = Slot3.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot3.color = color;

            gameManager.instance.coin -= 60;
            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            gameManager.instance.Oxygen = 320;
            Debug.Log("상품 구매");
            gameManager.instance.itP3 = true;
        }
    }

    // 대형 가방
    public void Purchase4()
    {
        if (gameManager.instance.itP4 || gameManager.instance.itP5)
        {
            Debug.Log("이미 구매함");
            Color color = Slot4.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot4.color = color;
            return;
        }
        if (gameManager.instance.itFree)
        {
            Color color = Slot4.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot4.color = color;

            gameManager.instance.SlotO1 = true;
            gameManager.instance.MaxWeight = 250;
            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            
            Debug.Log("상품 구매");
            gameManager.instance.itP4 = true;
            return;
        }
        if (gameManager.instance.coin >= 40)
        {
            Color color = Slot4.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot4.color = color;

            gameManager.instance.SlotO1 = true;
            gameManager.instance.coin -= 40;
            gameManager.instance.MaxWeight = 250;
            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            
            Debug.Log("상품 구매");
            gameManager.instance.itP4 = true;
        }
    }

    // 초대형 가방
    public void Purchase5()
    {
        if (gameManager.instance.itP5)
        {
            Debug.Log("이미 구매함");
            Color color = Slot5.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot5.color = color;
            return;
        }
        if (gameManager.instance.itFree)
        {
            Color color = Slot5.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot5.color = color;

            gameManager.instance.SlotO1 = true;
            gameManager.instance.SlotO2 = true;
            gameManager.instance.MaxWeight = 400;
            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            
            Debug.Log("상품 구매");
            gameManager.instance.itP5 = true;
            return;
        }
        if (gameManager.instance.coin >= 80)
        {
            Color color = Slot5.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot5.color = color;

            gameManager.instance.coin -= 80;

            gameManager.instance.SlotO1 = true;
            gameManager.instance.SlotO2 = true;
            gameManager.instance.MaxWeight = 400;
            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            
            Debug.Log("상품 구매");
            gameManager.instance.itP5 = true;
        }
    }
    // 수류탄
    public void Purchase6()
    {
        if (gameManager.instance.itP6)
        {
            Debug.Log("이미 구매함");
            Color color = Slot6.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot6.color = color;
            return;
        }
        if (gameManager.instance.itFree)
        {
            Color color = Slot6.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot6.color = color;

            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            gameManager.instance.grCount = 2;
            Debug.Log("상품 구매");
            gameManager.instance.itP6 = true;
            return;
        }
        if (gameManager.instance.coin >= 200)
        {
            Color color = Slot6.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }
            Slot6.color = color;
            
            gameManager.instance.coin -= 200;
            Coin.text = "COIN: " + gameManager.instance.coin.ToString();
            gameManager.instance.grCount = 2;
            Debug.Log("상품 구매");
            gameManager.instance.itP6 = true;
        }
    }
}
