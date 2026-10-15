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
        PlayerInfo playerInfo = GameObject.Find("InfoG").GetComponent<PlayerInfo>();

        if (btnName.name.Contains("Boss"))
        {
            Debug.Log("Boss Room");
            LoadScene(0, playerInfo);
        }
        else if (btnName.name.Contains("Rest"))
        {
            Debug.Log("Rest Room");
            playerInfo.Rest();
        }
        else if (btnName.name.Contains("Monster"))
        {
            Debug.Log("Monster Room");
            LoadScene(2, playerInfo);
        }
        else if (btnName.name.Contains("Loot"))
        {
            Debug.Log("Loot Room");
            LoadScene(3, playerInfo);
        }
        else if (btnName.name.Contains("Random"))
        {
            Debug.Log("Random Room");
            LoadScene(4, playerInfo);
        }
    }

    void LoadScene(int sceneName, PlayerInfo playerInfo)
    {
        playerInfo.loadRoom = sceneName;
        UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
    }
}
