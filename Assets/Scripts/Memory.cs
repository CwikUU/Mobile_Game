using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Memory : MonoBehaviour
{
    public GameObject boardGrid;
    public List<CardInfo> cards = new();
    public CardDB cardDB;

    public List<CardInfo> cardTaked = new();
    public List<GameObject> cardShowed = new();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < cardDB.cardInfos.Length; i++)
        {
            if (cardDB.cardInfos[i].equipped)
            {
                cards.Add(cardDB.cardInfos[i]);
            }
        }

        for (int i = 0; i < 8; i++)
        {
            cards.Add(cards[i]);
        }

    }

    private void Update()
    {
        if (cardShowed.Count == 2)
        {
            if (cardShowed[0].name == cardShowed[1].name)
            {
                cardTaked.Add(cards.Find(x => x.cardName == cardShowed[0].name));
                foreach(var item in cardShowed)
                {
                    item.GetComponent<Button>().interactable = false;
                }
                cardShowed.Clear();
            }
            else
            {
                foreach (var item in cardShowed)
                {
                    item.GetComponent<CardShowing>().cardAvers.SetActive(false);
                }
                cardShowed.Clear();
            }
        }
    }

    public void ShuffleCards()
    {
        for (int i = 0; i < 99; i++)
        {
            int index1 = UnityEngine.Random.Range(0, cards.Count - 1);
            int index2 = UnityEngine.Random.Range(0, cards.Count - 1);
            CardInfo temp = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = temp;
        }

        AddToBoard();
    }

    void AddToBoard()
    {
        for (int i = 0; i < boardGrid.transform.childCount; i++)
        {
            Destroy(boardGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < cards.Count; i++)
        {
            GameObject card = Instantiate(cards[i].cardPrefab, boardGrid.transform);
            card.name = cards[i].cardName;

            TMPro.TextMeshProUGUI texts = card.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            texts.text = card.name;
        }
    }
}
