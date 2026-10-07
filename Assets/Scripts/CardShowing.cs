using UnityEngine;

public class CardShowing : MonoBehaviour
{

    public GameObject cardAvers;

   public void ShowCard()
    {
        if (!cardAvers.activeSelf) cardAvers.SetActive(true);

        GameObject.Find("MemoryControl").GetComponent<Memory>().cardShowed.Add(gameObject);
    }
    
}
