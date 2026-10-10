using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

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
    public List<GameObject> roomList;
    public List<GameObject> emptyRooms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DungeonControl dungeonControl = GameObject.Find("DungeonControl").GetComponent<DungeonControl>();

        ///  mysl tworzenie lsity z pustymi jeszcze pokijami     kazdy startowy pokoj to monster abo random (jesli jest random) reszta to losowo z pozostalych wonych pokoi

        if (this.gameObject.name.Contains("5"))
        {
            Instantiate(dungeonControl.rooms[0], bossRoom.transform);

            for (int i = 0; i < restAmount; i++)
            {
                roomList.Add(dungeonControl.rooms[1]);
            }

            for (int i = 0; i < monsterAmount; i++)
            {
                roomList.Add(dungeonControl.rooms[2]);
            }

            for (int i = 0; i < lootAmount; i++)
            {
                roomList.Add(dungeonControl.rooms[3]);
            }

            for (int i = 0; i < randomAmount; i++)
            {
                roomList.Add(dungeonControl.rooms[4]);
            }

            for (int i = 0; i < bossAmount; i++)
            {
                roomList.Add(dungeonControl.rooms[0]);
            }

            if(roomList.Count < 6)
            {
                int left = 5 - roomList.Count;
                for (int i = 0; i < left; i++)
                {
                    int randomIndex = Random.Range(2, 5);
                    roomList.Add(dungeonControl.rooms[randomIndex]);
                }
            }


        }
    }
}
