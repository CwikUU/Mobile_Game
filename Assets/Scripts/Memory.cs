using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Memory : MonoBehaviour
{
    [Header("Scene Stage")]
    public bool memoryStage = false;
    public bool battleStage = false;
    public int currentRoom = -1;

    [Header("Timer")]
    public float timer = -1000;
    public TextMeshProUGUI timeLeft;
    
    [Header("Memory Board")]
    public GameObject boardGrid;
    public List<CardInfo> cards = new();

    public List<CardInfo> cardTaked = new();
    public List<GameObject> cardShowed1 = new();
    public bool showingCards = false;

    [Header("Loot")]
    public List<int> lootList = new();
    public List<LootInfo> lootCards = new();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInfo playerInfo = GameObject.Find("InfoG").GetComponent<PlayerInfo>();
        CardDB cardDB = GameObject.Find("InfoG").GetComponent<CardDB>();

        currentRoom = playerInfo.loadRoom;

        if (currentRoom == 0 || currentRoom == 2)
        {
            PrepareBattleMemory(playerInfo, cardDB);
        }

        if (currentRoom == 3)
        {
            GenerateProcentageList(
                50, //common
                40, // uncommon
                20, // rare
                10, //epic
                2); // legendary
            PrepareLootMemory(cardDB);
        }

        if (currentRoom == 4)
        {
            int rng = UnityEngine.Random.Range(1,11);

            if (rng % 2 == 0)
            {
                PrepareBattleMemory(playerInfo, cardDB);
            }
            else
            {
                GenerateProcentageList(
                    UnityEngine.Random.Range(1, 5) * 15, // common
                    UnityEngine.Random.Range(1, 4) * 10,// uncommon
                    UnityEngine.Random.Range(1, 4) * 7,// rare
                    UnityEngine.Random.Range(1, 3) * 2,// epic
                    UnityEngine.Random.Range(1, 3) * 1);// legendary
                PrepareLootMemory(cardDB);
            }
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int left = (int)timer;
            timeLeft.text = left.ToString();
        }
    }

    private void FixedUpdate()
    {
        if (cardShowed1.Count == 2)
        {
            if (cardShowed1[0].name == cardShowed1[1].name)   // cards matched
            {
                cardTaked.Add(cards.Find(x => x.cardName == cardShowed1[0].name));
                foreach (var item in cardShowed1)
                {
                    item.GetComponent<Button>().interactable = false;
                }
                cardShowed1.Clear();
            }
            else                // cards not matched
            {
                if (!showingCards) StartCoroutine(ClearNotMatched(.5f));
            }
        }
    }

    public void ShuffleCards(int whatAdd) // 0 - Battle Deck , 1 - Loot Deck
    {
        for (int i = 0; i < 99; i++)
        {
            int index1 = UnityEngine.Random.Range(0, cards.Count - 1);
            int index2 = UnityEngine.Random.Range(0, cards.Count - 1);

            if (whatAdd == 0)
            {
                CardInfo temp = cards[index1];
                cards[index1] = cards[index2];
                cards[index2] = temp;
            }
            else
            {
                LootInfo temp = lootCards[index1];
                lootCards[index1] = lootCards[index2];
                lootCards[index2] = temp;
            }
        }

        AddToBoard(whatAdd);
    }

    void AddToBoard(int whatAdd) // 0 - Battle Deck , 1 - Loot Deck
    {
        for (int i = 0; i < boardGrid.transform.childCount; i++)
        {
            Destroy(boardGrid.transform.GetChild(i).gameObject);
        }

        if (whatAdd == 0)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                GameObject card = Instantiate(cards[i].cardPrefab, boardGrid.transform);
                card.name = cards[i].cardName;

                TMPro.TextMeshProUGUI texts = card.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                texts.text = card.name;
            }
        }
        else
        {
            for (int i = 0; i < cards.Count; i++)
            {
                GameObject lootCard = Instantiate(lootCards[i].lootPrefab, boardGrid.transform);
                lootCard.name = lootCards[i].lootName;

                TMPro.TextMeshProUGUI texts = lootCard.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                texts.text = lootCard.name;
            }
        }

        memoryStage = true;
    }

    IEnumerator ClearNotMatched(float seconds)
    {
        showingCards = true;
        yield return new WaitForSeconds(seconds);
        Debug.Log("1s");
        foreach (var item in cardShowed1)
        {
            item.GetComponent<CardShowing>().cardAvers.SetActive(false);
            item.GetComponent<Button>().interactable = true;
        }
        Debug.Log("cleared");
        cardShowed1.Clear();
        showingCards = false;
    }

    void PrepareBattleMemory(PlayerInfo playerInfo, CardDB  cardDB)
    {
        foreach (var card in playerInfo.deck)
        {
            cards.Add(card);
        }

        if (cards.Count < 8)
        {
            int left = 8 - cards.Count;

            int blankID = System.Array.FindIndex(cardDB.cardInfos, x => x.cardName == "blank");
            int monsterID = System.Array.FindIndex(cardDB.cardInfos, x => x.cardName == "monster");
            for (int i = 0; i < left - 1; i++)
            {
                cards.Add(cardDB.cardInfos[blankID]); // add blank cards if not enough cards in deck
            }
            cards.Add(cardDB.cardInfos[monsterID]); // add monster card if not enough cards in deck
        }

        for (int i = 0; i < 8; i++)
        {
            cards.Add(cards[i]);
        }

        ShuffleCards(0);
    }

    void PrepareLootMemory(CardDB cardDB)
    {
        // Implement loot memory preparation logic here

        for (int i = 0; i < 8; i++)
        {
            int rarity = lootList[UnityEngine.Random.Range(0, lootList.Count - 1)];

            switch (rarity)
            {
                case 0:
                    lootCards.Add(cardDB.common[UnityEngine.Random.Range(0, cardDB.common.Length - 1)]);
                    break;
                case 1:
                    lootCards.Add(cardDB.uncommon[UnityEngine.Random.Range(0, cardDB.uncommon.Length - 1)]);
                    break;
                case 2:
                    lootCards.Add(cardDB.rare[UnityEngine.Random.Range(0, cardDB.rare.Length - 1)]);
                    break;
                case 3:
                    lootCards.Add(cardDB.epic[UnityEngine.Random.Range(0, cardDB.epic.Length - 1)]);
                    break;
                case 4:
                    lootCards.Add(cardDB.legendary[UnityEngine.Random.Range(0, cardDB.legendary.Length - 1)]);
                    break;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            lootCards.Add(lootCards[i]);
        }

        ShuffleCards(1);
    }

    void GenerateProcentageList(int commonAmount, int uncommonAmount, int rareAmount, int epicAmount, int legendaryAmount)
    {
        for (int i = 0; i < commonAmount ; i++)
        {
            lootList.Add(0);
        }
        for (int i = 0; i < uncommonAmount; i++)
        {
            lootList.Add(1);
        }
        for (int i = 0; i < rareAmount; i++)
        {
            lootList.Add(2);
        }
        for (int i = 0; i < epicAmount; i++)
        {
            lootList.Add(3);
        }
        for (int i = 0; i < legendaryAmount; i++)
        {
            lootList.Add(4);
        }

        for (int i = 0; i < lootList.Count; i++)
        {
            int index1 = UnityEngine.Random.Range(0, lootList.Count - 1);
            int index2 = UnityEngine.Random.Range(0, lootList.Count - 1);
            int temp = lootList[index1];
            lootList[index1] = lootList[index2];
            lootList[index2] = temp;
        }
    }

    public void StartGame(GameObject btn)
    {
        if (timer <= -1000)timer = 30;
        btn.SetActive(false);
    }
}
