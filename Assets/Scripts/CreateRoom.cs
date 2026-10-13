using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{
    public bool roomsCreated = false;

    [Header("Rooms")]
    public GameObject bossRoom;
    public GameObject[] startRoom;

    [Header("Minimal Amount of Rooms")]
    public int bossAmount = 0; // [0]
    public int restAmount = 0; // [1]
    public int monsterAmount = 0; // [2]
    public int lootAmount = 0; // [3]
    public int randomAmount = 0; // [4]

    [Header("Room List")]
    public List<string> roomList;
    public List<GameObject> emptyRooms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DungeonControl dungeonControl = GameObject.Find("SceneControl").GetComponent<DungeonControl>();

        PlayerInfo playerInfo = GameObject.Find("InfoG").GetComponent<PlayerInfo>();

        if (playerInfo.dungeonIsGenerated == false)
        {
            foreach (Transform child in transform)
            {
                emptyRooms.Add(child.gameObject);
            }

            if (this.gameObject.name.Contains("5"))
            {
                CreateDungeon(5, dungeonControl);
            }
            if (this.gameObject.name.Contains("7"))
            {
                CreateDungeon(7, dungeonControl);
            }
            if (this.gameObject.name.Contains("9"))
            {
                CreateDungeon(9, dungeonControl);
            }

            playerInfo.dungeonIsGenerated = true;
            dungeonControl.UpdateDungeon();
        }
    }


    void CreateDungeon(int size, DungeonControl dungeonControl)
    {
        for (int i = 0; i < restAmount; i++) // rest
        {
            roomList.Add(dungeonControl.rooms[1].name);
        }

        for (int i = 0; i < monsterAmount; i++)
        {
            roomList.Add(dungeonControl.rooms[2].name); // monster
        }

        for (int i = 0; i < lootAmount; i++)
        {
            roomList.Add(dungeonControl.rooms[3].name); // loot
        }

        for (int i = 0; i < randomAmount; i++)
        {
            roomList.Add(dungeonControl.rooms[4].name); // random
        }

        for (int i = 0; i < bossAmount; i++)
        {
            roomList.Add(dungeonControl.rooms[0].name); // boss
        }

        if (roomList.Count < size + 1)
        {
            int left = size - roomList.Count;
            for (int i = 0; i < left; i++)
            {
                int randomIndex = Random.Range(2, 5);
                roomList.Add(dungeonControl.rooms[randomIndex].name);
            }
        }

        bossRoom.transform.GetChild(0).gameObject.name = "Boss";
        int delBoss = emptyRooms.FindIndex(x => x.name == bossRoom.name);
        emptyRooms.RemoveAt(delBoss);

        for (int i = 0; i < startRoom.Length; i++)
        {
            int monsterStart = roomList.FindIndex(x => x.Contains("Monster"));
            startRoom[i].transform.GetChild(0).gameObject.name = roomList[monsterStart];
            roomList.RemoveAt(monsterStart);
            int delRoom = emptyRooms.FindIndex(x => x.name == startRoom[i].name);
            emptyRooms.RemoveAt(delRoom);
        }

        for (int i = emptyRooms.Count - 1; i >= 0; i--)
        {
            int randomIndex = Random.Range(0, roomList.Count);
            emptyRooms[i].transform.GetChild(0).gameObject.name = roomList[randomIndex];
            roomList.RemoveAt(randomIndex);
            emptyRooms.RemoveAt(i);
        }

        foreach (Transform child in transform)
        {
            if(child.GetChild(0).gameObject.name.Contains("Monster"))
            {
                Image image = child.GetChild(0).gameObject.GetComponent<Image>();
                image.color = Color.grey;
            }
            if(child.GetChild(0).gameObject.name.Contains("Loot"))
            {
                Image image = child.GetChild(0).gameObject.GetComponent<Image>();
                image.color = Color.orange;
            }
            if(child.GetChild(0).gameObject.name.Contains("Random"))
            {
                child.GetChild(0).gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "?";
            }
            if(child.GetChild(0).gameObject.name.Contains("Boss"))
            {
                Image image = child.GetChild(0).gameObject.GetComponent<Image>();
                image.color = Color.darkRed;
            }
            if(child.GetChild(0).gameObject.name.Contains("Rest"))
            {
                Image image = child.GetChild(0).gameObject.GetComponent<Image>();
                image.color = Color.lightGreen;
            }
        }
    }
}
