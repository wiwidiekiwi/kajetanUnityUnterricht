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
        buttonNewGame.onClick.AddListener(StartNewGame);
    }

    void ShowLevelSelection()
    {
        panelMain.HideCanvasGroup();
        panelLevelSelection.ShowCanvasGroup();
    }

    void ShowMainPanel()
    {
        panelMain.ShowCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
    }

    void StartNewGame()
    {
        //LoadLevel1
        SceneManager.LoadScene(levelNames[0]);
    }

  
}
