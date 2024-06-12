using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelMain;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonLevelSelection;
    [SerializeField] private Button buttonExitGame;

    [SerializeField] private CanvasGroup panelLevelSelection;
    [SerializeField] private Button buttonBackToMain;
    [SerializeField] private Button buttonLevel1;
    [SerializeField] private Button buttonLevel2;
    [SerializeField] private Button buttonLevel3;

    [SerializeField] private string[] levelNames;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ShowMainPanel();
        
        buttonLevelSelection.onClick.AddListener(ShowLevelSelection);
        buttonBackToMain.onClick.AddListener(ShowMainPanel);
        buttonNewGame.onClick.AddListener(LoadLevel1);
        
        buttonLevel1.onClick.AddListener(LoadLevel1);
        buttonLevel2.onClick.AddListener(LoadLevel2);
        buttonLevel3.onClick.AddListener(LoadLevel3);
        
        buttonExitGame.onClick.AddListener(ExitGame);
        // makes the button non interactable aslong you haven't completed the levels before

        buttonLevel2.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[1]))
        {
            if (PlayerPrefs.GetInt(levelNames[1]) == 1)
            {
                buttonLevel2.interactable = true;
            }
        }

        buttonLevel3.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[2]))
        {
            if (PlayerPrefs.GetInt(levelNames[2]) == 1)
            {
                buttonLevel3.interactable = true;
            }
        }
    }

    void ShowLevelSelection()
    {
        // main panel -> hide/ level selection panel -> shown
        panelMain.HideCanvasGroup();
        panelLevelSelection.ShowCanvasGroup();
    }

    void ShowMainPanel()
    {
        // main panel -> shown/ level selection panel -> hide
        panelMain.ShowCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
    }

    void LoadLevel1()
    {
        //LoadLevel1
        SceneManager.LoadScene(levelNames[0]);
    }

    void LoadLevel2()
    {
        //LoadLevel2
        SceneManager.LoadScene(levelNames[1]);
    }

    void LoadLevel3()
    {
        //LoadLevel3
        SceneManager.LoadScene(levelNames[2]);
    }

    void ExitGame()
    {
        // when the game is build the game can be closed by the button assigned with this function
        Application.Quit();
    }

  
}
