using TMPro;
using UnityEngine;

public class Battle : MonoBehaviour
{
    CardDB cardDB;
    PlayerInfo playerInfo;

    [Header("Monster")]
    public int maxHP;
    public MonsterInfo monsterInfo;

    [Header("Monster UI")]
    public TextMeshProUGUI hpM;
    public TextMeshProUGUI actionValue;
    public GameObject actionIcon;

    [Header("Player UI")]
    public TextMeshProUGUI hpPl;
    public TextMeshProUGUI staminaPl;
    public TextMeshProUGUI mpPl;


    private void Start()
    {
        playerInfo = GameObject.Find("InfoG").GetComponent<PlayerInfo>();
        cardDB = GameObject.Find("InfoG").GetComponent<CardDB>();

        monsterInfo = cardDB.monsters[UnityEngine.Random.Range(0, cardDB.monsters.Length)];
        maxHP = monsterInfo.monsterHP;
    }

    private void Update()
    {
        hpM.text = "HP " + monsterInfo.monsterHP + "/" + maxHP.ToString();

        hpPl.text = "HP " + playerInfo.health + "/" + playerInfo.healthMax;
        staminaPl.text = "ST " + playerInfo.stamina + "/" + playerInfo.staminaMax;
        mpPl.text = "MP " + playerInfo.mana + "/" + playerInfo.manaMax;
    }
}
