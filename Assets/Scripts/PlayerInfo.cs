using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public string className;
    public int healthMax;
    public int health;
    public int staminaMax;
    public int stamina;
    public int manaMax;
    public int mana;
    public int money;

    public List<CardInfo> deck = new List<CardInfo>();

    public GameObject dungeonMap;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        GameObject info = GameObject.Find("InfoG");

        if (info == null)
        {
            this.gameObject.name = "InfoG";
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
