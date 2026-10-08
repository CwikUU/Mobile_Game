using UnityEngine;
using UnityEngine.UI;

public class CardShowing : MonoBehaviour
{

    public GameObject cardAvers;

   public void ShowCard()
    {

        Memory showedCards = GameObject.Find("MemoryControl").GetComponent<Memory>();

        if (showedCards != null)
        {
            if (showedCards.cardShowed1.Count < 2)
            {
                this.gameObject.GetComponent<Button>().interactable = false;
                if (!cardAvers.activeSelf) cardAvers.SetActive(true);
                showedCards.cardShowed1.Add(this.gameObject);
            }
        }
    }
    
}
