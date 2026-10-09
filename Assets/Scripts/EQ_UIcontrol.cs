using TMPro;
using UnityEngine;

public class EQ_UIcontrol : MonoBehaviour
{
    [Header("UI Top")]
    public GameObject OptionsBTN;
    public GameObject EQbtn;
    public GameObject HpMpSta;
    public GameObject coins;

    [Header("UI EQ")]
    public GameObject EQui;
    public GameObject cards;
    public GameObject items;

    [Header("Options")]
    public GameObject Options;

    PlayerInfo player;

    private void Start()
    {
        EQui.SetActive(false);
        Options.SetActive(false);

        player = GameObject.Find("Info").GetComponent<PlayerInfo>();
    }

    private void Update()
    {
        if (player != null)
        {
            HpMpSta.transform.Find("HP").GetComponent<TextMeshProUGUI>().text = player.health + "/" + player.healthMax;
            HpMpSta.transform.Find("MP").GetComponent<TextMeshProUGUI>().text = player.mana + "/" + player.manaMax;
            HpMpSta.transform.Find("Stamina").GetComponent<TextMeshProUGUI>().text = player.stamina + "/" + player.staminaMax;
            
            coins.transform.Find("money").GetComponent<TextMeshProUGUI>().text = player.money.ToString();
        }
    }

    public void ShowEQ(int index) // 0 = open Cards, 1 = open Items, 2 = close/open EQ
    {
        if (index == 0)
        {
            cards.SetActive(true);
            items.SetActive(false);
        }
        else if (index == 1)
        {
            cards.SetActive(false);
            items.SetActive(true);
        }
        else if (index == 2)
        {
            EQui.SetActive(!EQui.activeSelf);
        }

    }

    public void OptionMenu()
    {
        Options.SetActive(!Options.activeSelf);
    }

    public void ToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}
