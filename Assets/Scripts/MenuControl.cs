using System.Collections;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject classMenu;
    public GameObject credits;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainMenu();
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        classMenu.SetActive(false);
        credits.SetActive(false);
    }

    public void ClassMenu()
    {
        mainMenu.SetActive(false);
        classMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        classMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(.3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("TownScene");
    }
}
