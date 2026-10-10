using UnityEngine;

public class DungeonControl : MonoBehaviour
{

    public GameObject dungeonBoard;

    [Header("Dungeon 5 rooms prefabs")]
    public GameObject r5v1;
    public GameObject r5v2;
    public GameObject r5v3;

    [Header("Dungeon 7 rooms prefabs")]
    public GameObject r7v1;
    public GameObject r7v2;
    public GameObject r7v3;

    [Header("Dungeon 9 rooms prefabs")]
    public GameObject r9v1;
    public GameObject r9v2;
    public GameObject r9v3;

    [Header("Rooms Prefabs")]
    public GameObject[] rooms;
    //public GameObject boss; 0
    //public GameObject rest; 1
    //public GameObject monster; 2
    //public GameObject loot; 3
    //public GameObject random; 4

    private void Start()
    {
        PlayerInfo playerInfo = GameObject.Find("InfoG").GetComponent<PlayerInfo>();

        if (playerInfo != null)
        {
            if (playerInfo.dungeonMap == null)
            {
                int random = Random.Range(1, 4);
                switch (random)
                {
                    case 1:
                        random = Random.Range(1, 4);
                        if (random == 1)
                        {
                            playerInfo.dungeonMap = r5v1;
                            CreateDungeon(r5v1);
                        }
                        else if (random == 2)
                        {
                            playerInfo.dungeonMap = r5v2;
                            CreateDungeon(r5v2);
                        }
                        else
                        {
                            playerInfo.dungeonMap = r5v3;
                            CreateDungeon(r5v3);
                        }
                        break;
                    case 2:
                        random = Random.Range(1, 4);
                        if (random == 1)
                        {
                            playerInfo.dungeonMap = r7v1;
                            CreateDungeon(r7v1);
                        }
                        else if (random == 2)
                        {
                            playerInfo.dungeonMap = r7v2;
                            CreateDungeon(r7v2);
                        }
                        else
                        {
                            playerInfo.dungeonMap = r7v3;
                            CreateDungeon(r7v3);
                        }
                        break;
                    case 3:
                        random = Random.Range(1, 4);
                        if (random == 1)
                        {
                            playerInfo.dungeonMap = r9v1;
                            CreateDungeon(r9v1);
                        }
                        else if (random == 2)
                        {
                            playerInfo.dungeonMap = r9v2;
                            CreateDungeon(r9v2);
                        }
                        else
                        {
                            playerInfo.dungeonMap = r9v3;
                            CreateDungeon(r9v3);
                        }
                        break;
                }
            }
            else
            {
                CreateDungeon(playerInfo.dungeonMap);
            }
        }
    }

    void CreateDungeon(GameObject dungeonPrefab)
    {
        Instantiate(dungeonPrefab, dungeonBoard.transform);
    }
}
