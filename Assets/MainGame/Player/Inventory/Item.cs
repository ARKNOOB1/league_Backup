using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    public int weight;
    public int price;

    public Item(string name, int weight, int price)
    {
        this.name = name;
        this.weight = weight;
        this.price = price;
    }
}
