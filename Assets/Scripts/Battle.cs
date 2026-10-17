using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Battle : MonoBehaviour
{
    CardDB cardDB;
    PlayerInfo playerInfo;

    [Header("Turn Info")]
    public int turn = 1;
    public bool playerTurn;
    public bool monsterTurn;

    [Header("Monster")]
    public int maxHP;
    public MonsterInfo monsterInfo;

    [Header("Monster UI")]
    public TextMeshProUGUI hpM;
    public TextMeshProUGUI armorM;
    public TextMeshProUGUI actionValue;
    public GameObject actionIcon;

    [Header("Player UI")]
    public TextMeshProUGUI hpPl;
    public TextMeshProUGUI staminaPl;
    public TextMeshProUGUI mpPl;
    public TextMeshProUGUI armorPl;
    public GameObject blockInteraction;


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
        armorM.text = monsterInfo.block.ToString();

        hpPl.text = "HP " + playerInfo.health + "/" + playerInfo.healthMax;
        staminaPl.text = "ST " + playerInfo.stamina + "/" + playerInfo.staminaMax;
        mpPl.text = "MP " + playerInfo.mana + "/" + playerInfo.manaMax;
        armorPl.text = playerInfo.armor.ToString();
    }


    public void EndPlayerTurn()
    {
        blockInteraction.SetActive(true);
        playerTurn = false;
        monsterTurn = true;
        StartCoroutine(MonsterTurn() );
    }
    
    public void EndMonsterTurn()
    {
        blockInteraction.SetActive(false);
        playerTurn = true;
        monsterTurn = false;

        turn += 1;
    }

    private void StartMonsterTurn()
    {
        throw new NotImplementedException();
    }

    IEnumerator MonsterTurn()
    {
        monsterInfo.block = 0;
        MonsterAttackTurn monsterAction = monsterInfo.attacks[turn-1];

        /// some day there we be check negative status before turn
        
        if (monsterAction.block)
        {
            monsterInfo.block += monsterAction.actionValue;
        }

        if (monsterAction.attack)
        {
            playerInfo.DamagePlayer(monsterAction.actionValue);
            //start animation or smthg

        }
        /// some day there we be check negative status after turn
        /// 
        EndMonsterTurn();
        yield return null;
    }
}
