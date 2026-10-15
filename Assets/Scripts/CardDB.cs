using UnityEngine;

[System.Serializable]
public class LootInfo
{
    public string lootName;
    public int lootRarity;
    public string lootDescription;
    public GameObject lootPrefab;
}

public class CardDB : MonoBehaviour
{
    public CardInfo[] cardInfos;
    public LootInfo[] lootInfos;
}
