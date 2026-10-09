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

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
