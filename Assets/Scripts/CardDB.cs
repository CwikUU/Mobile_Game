using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class LootInfo
{
    public string lootName;
    public string lootDescription;
    public GameObject lootPrefab;
}

[System.Serializable]
public class MonsterAttackTurn  
{
    public bool attack;
    public bool block;
    public int actionValue;
}

[System.Serializable]
public class MonsterInfo
{
    public string monsterName;
    public int monsterHP;
    public int block;
    [Tooltip("element0 - turn1 , element1 - turn2 , ...")]
    public MonsterAttackTurn[] attacks;
    public GameObject monsterPrefab;
}


public class CardDB : MonoBehaviour
{
    [Header("Eq cards")]
    public CardInfo[] cardInfos;

    [Header("Loot cards")]
    public LootInfo[] common;
    public LootInfo[] uncommon;
    public LootInfo[] rare;
    public LootInfo[] epic;
    public LootInfo[] legendary;

    [Header("Monsters")]
    public MonsterInfo[] monsters;
    public MonsterInfo[] boss;
}
