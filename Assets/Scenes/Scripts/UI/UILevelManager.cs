using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILevelManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelWin;
    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonPlayAgainWin;
    [SerializeField] private Button buttonBackToMenu1;
    
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private Button buttonPlayAgainLose;
    [SerializeField] private Button buttonBackToMenu2;

    [SerializeField] private CanvasGroup panelPause;
    [SerializeField] private Button buttonContinue;
    [SerializeField] private Button buttonBackToMenu3;

    [SerializeField] private string nameNextScene;

    private int coinCount = 0;
    [SerializeField] private TextMeshProUGUI txtCoincount;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        txtCoincount.text = coinCount.ToString();
        //win, pause and lose screen -> hide

        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();
        panelPause.HideCanvasGroup();
        
        buttonPlayAgainWin.onClick.AddListener(RestartLevel);
        buttonPlayAgainLose.onClick.AddListener(RestartLevel);
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
        buttonContinue.onClick.AddListener(ContinueTheGame);
        
        buttonBackToMenu1.onClick.AddListener(BackToMenu);
        buttonBackToMenu2.onClick.AddListener(BackToMenu);
        buttonBackToMenu3.onClick.AddListener(BackToMenu);
    }

    public void OnGameWin()
    {
        //winscreen -> show
        panelWin.ShowCanvasGroup();
        PlayerPrefs.SetInt(nameNextScene, 1);
        Time.timeScale = 0f;
    }

    public void OnGameLose()
    {
        //losescreen -> show
        panelLose.ShowCanvasGroup();
        Time.timeScale = 0f;
    }

    public void AddCoin()
    {
        coinCount++; // ++ short for +1
        txtCoincount.text = coinCount.ToString(); // turns the integer into a string, so it can be shown on the screen
    }

    void RestartLevel()
    {
        //reload current Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        // loads the next scene, the next scene is being determined by us/me
        SceneManager.LoadScene(nameNextScene);
    }

    void BackToMenu()
    {
        // loads the menu scene
        SceneManager.LoadScene("Menu");
    }

    void OnPause(InputValue inputValue)
    {
        // press esc then the timescale is 0 and a panel pops up where you can go back to the menu
        Debug.Log("paused");
        panelPause.ShowCanvasGroup();
        Time.timeScale = 0f;
    }

    void ContinueTheGame()
    {
        // press button then the panel disappears and you continue the game
        panelPause.HideCanvasGroup();
        Time.timeScale = 1f;
    }

   
}


public static class UIExtensions
{
    public static void HideCanvasGroup(this CanvasGroup canvasGroup)
    {
        // panel is made invisible, non interactable and it no longer blocks raycasts
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    
    public static void ShowCanvasGroup(this CanvasGroup canvasGroup)
    {
        // panel is made visible, interactable and it blocks raycasts
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}