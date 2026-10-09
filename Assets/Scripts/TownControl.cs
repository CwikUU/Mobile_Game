using UnityEngine;

public class TownControl : MonoBehaviour
{

    public GameObject City;
    public GameObject TavernUI;
    public GameObject GuildUI;
    public GameObject MarketUI;
    public GameObject EnchanterUI;


    private void Start()
    {
        CityButton();
    }

    public void CityButton()
    {
        City.SetActive(true);
        TavernUI.SetActive(false);
        GuildUI.SetActive(false);
        MarketUI.SetActive(false);
        EnchanterUI.SetActive(false);
    }

    public void GoTo(int location) // 0 = Tavern, 1 = Guild, 2 = Market, 3 = Enchanter
    {
        City.SetActive(false);
        TavernUI.SetActive(location == 0);
        GuildUI.SetActive(location == 1);
        MarketUI.SetActive(location == 2);
        EnchanterUI.SetActive(location == 3);
    }

    public void BattleSCene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
    }

    public void DungeonScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DungeonScene");
    }
}
