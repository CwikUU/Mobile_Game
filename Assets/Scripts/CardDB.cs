using UnityEngine;

[System.Serializable]
public class LootInfo
{
    public string lootName;
    public string lootDescription;
    public GameObject lootPrefab;
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
}
