using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    [Header("Player Info")]
    public string className;
    public int healthMax;
    public int health;
    public int staminaMax;
    public int stamina;
    public int manaMax;
    public int mana;
    public int money;

    public List<CardInfo> deck = new List<CardInfo>();


    [Header("Dungeon Info")]
    public GameObject dungeonMap;
    public bool dungeonIsGenerated = false;
    public int loadRoom;

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

    public void SaveCurrentDungeon()
    {
        if (dungeonMap != null)
        {
            dungeonMap.transform.SetParent(this.transform);
        }
    }

    public void LoadCurrentDungeon(GameObject dungBoard)
    {
        if (dungeonMap != null)
        {
            dungeonMap.transform.SetParent(dungBoard.transform);
        }
    }

    public void Rest()
    {
        health += (int)(healthMax * .2f);
        stamina += (int)(staminaMax * .2f);
        mana += (int)(manaMax * .1f);

        if (health > healthMax)
        {
            health = healthMax;
        }
        if (stamina > staminaMax)
        {
            stamina = staminaMax;
        }
        if (mana > manaMax)
        {
            mana = manaMax;
        }
    }
}