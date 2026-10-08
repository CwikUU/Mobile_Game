using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Memory : MonoBehaviour
{
    public GameObject boardGrid;
    public List<CardInfo> cards = new();

    public List<CardInfo> cardTaked = new();
    public List<GameObject> cardShowed1 = new();
    public bool showingCards = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInfo playerInfo = GameObject.Find("Info").GetComponent<PlayerInfo>();
        CardDB cardDB = GameObject.Find("Info").GetComponent<CardDB>();


        foreach (var card in playerInfo.deck)
        {
            cards.Add(card);
        }

        if (cards.Count < 8)
        {
            int left = 8 - cards.Count;

            int blankID = System.Array.FindIndex(cardDB.cardInfos, x => x.cardType == "blank");
            int monsterID = System.Array.FindIndex(cardDB.cardInfos, x => x.cardType == "monster");
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
}
