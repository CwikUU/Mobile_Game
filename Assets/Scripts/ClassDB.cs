using UnityEngine;


[System.Serializable]
public class ClassInfo
{
    public string className;
    public int classHealth;
    public int classStamina;
    public int classMana;
    public int classMoney;
    public string[] startCards;
}

public class ClassDB : MonoBehaviour
{
    public ClassInfo[] classes;
    public PlayerInfo playerInfo;
    public CardDB cardDB;

    public void ChooseClass(string className)
    {
        foreach (ClassInfo c in classes)
        {
            if (c.className == className)
            {
                playerInfo.className = c.className;
                playerInfo.health = c.classHealth;
                playerInfo.healthMax = c.classHealth;
                playerInfo.stamina = c.classStamina;
                playerInfo.staminaMax = c.classStamina;
                playerInfo.mana = c.classMana;
                playerInfo.manaMax = c.classMana;
                playerInfo.money = c.classMoney;
                // Add starting cards to the player's deck
                foreach (string card in c.startCards)
                {
                    for (int i = 0; i < cardDB.cardInfos.Length; i++)
                    {
                        if (cardDB.cardInfos[i].cardName == card)
                        {
                            playerInfo.deck.Add(cardDB.cardInfos[i]);
                            break;
                        }
                    }
                }
                break;
            }
        }
    }
}
