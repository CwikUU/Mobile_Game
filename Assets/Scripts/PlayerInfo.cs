using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public string className;
    public int health;
    public int stamina;
    public int mana;
    public int money;

    public List<CardInfo> deck = new List<CardInfo>();

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
