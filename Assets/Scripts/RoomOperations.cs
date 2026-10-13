using UnityEngine;
using UnityEngine.UI;

public class RoomOperations : MonoBehaviour
{
    public void UnlockNextRooms(Button btn)
    {
        btn.interactable = true;
    }

    public void LockRooms(Button btn)
    {
        btn.interactable = false;
    }

    public void DoRoomOperation(GameObject btnName)
    {
        if(btnName.name.Contains("Boss"))
        {
            Debug.Log("Boss Room");
        }
        else if (btnName.name.Contains("Rest"))
        {
            Debug.Log("Rest Room");
        }
        else if (btnName.name.Contains("Monster"))
        {
            Debug.Log("Monster Room");
        }
        else if (btnName.name.Contains("Loot"))
        {
            Debug.Log("Loot Room");
        }
        else if (btnName.name.Contains("Random"))
        {
            Debug.Log("Random Room");
        }
    }
}
