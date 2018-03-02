using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    public void LoadInventory()
    {
        DataController data = FindObjectOfType<DataController>();
        data.soloDisplay = false;
        data.previousScene = "MenuScene";
        Debug.Log("Loading Inventory");
        SceneManager.LoadScene("InventoryScene", LoadSceneMode.Single);
    }

    public void LoadScanCard()
    {
        DataController data = FindObjectOfType<DataController>();
        data.soloDisplay = true;
        data.previousScene = "MenuScene";
        Debug.Log("Load Scan Card QR");
        SceneManager.LoadScene("ScanCardScene", LoadSceneMode.Single);
    }

    public void LoadRandomCard()
    {
        DataController data = FindObjectOfType<DataController>();
        data.soloDisplay = true;
        data.previousScene = "MenuScene";
        data.cardNumber = Random.Range(1, 52); //change this later once we have images for loot items outside of standard set
        SceneManager.LoadScene("ShowCardScene", LoadSceneMode.Single);
    }



    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        DataController data = FindObjectOfType<DataController>();

        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void LoadNewGame()
    {
        Debug.Log("Loading GameSystemsScene for new game");
        DataController data = FindObjectOfType<DataController>();
        data.continuingSession = false;
        SceneManager.LoadScene("NewSessionScene", LoadSceneMode.Single);
    }

    public void LoadContinueGame()
    {
        Debug.Log("Loading GameSystemsScene for continuing game");
        DataController data = FindObjectOfType<DataController>();
        data.continuingSession = true;

        SceneManager.LoadScene("LoadSessionScene", LoadSceneMode.Single);
    }

    public void LoadBugReport()
    {
        Debug.Log("Loading GameSystemsScene for continuing game");
        DataController data = FindObjectOfType<DataController>();
       

        SceneManager.LoadScene("BugReportScene", LoadSceneMode.Single);
    }

    public void LoadSettings()
    {
        Debug.Log("Loading Settings Menu");
        

        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Single);
    }

    public void LoadAbout()
    {
        Debug.Log("Loading About");
        SceneManager.LoadScene("AboutScene", LoadSceneMode.Single);
    }

    public void OpenWebshop()
    {
        Application.OpenURL("http://units.cards/shop/");
    }

}
