using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Text Rank1;
    public Text Rank2;
    public Text Rank3;
    public Text Rank4;
    public Text Rank5;

    List<string> texts;
    // Start is called before the first frame update
    void Start()
    {

        texts = new List<string>(5);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.instance.clear)
        {
            for (int i = 0; i < texts.Count; i++)
            {
                int timeM = (int)gameManager.instance.time / 60;
                int timeS = (int)gameManager.instance.time % 60;
                string text = timeM + ":" + timeS;
                texts.Add(text);
            }
            Rank1.text = "RANK: "+texts[0];
            Rank2.text = "RANK: " + texts[1];
            Rank3.text = "RANK: " + texts[2];
            Rank4.text = "RANK: " + texts[3];
            Rank5.text = "RANK: " + texts[4];
        }
    }
}
