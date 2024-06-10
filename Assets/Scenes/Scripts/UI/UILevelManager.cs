using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    [SerializeField] private string nameNextScene;

    private int coinCount = 0;
    [SerializeField] private TextMeshProUGUI txtCoincount;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        txtCoincount.text = coinCount.ToString();
        //win and lose screen -> hide

        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();
        
        buttonPlayAgainWin.onClick.AddListener(RestartLevel);
        buttonPlayAgainLose.onClick.AddListener(RestartLevel);
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
        
        buttonBackToMenu1.onClick.AddListener(BackToMenu);
        buttonBackToMenu2.onClick.AddListener(BackToMenu);
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
        coinCount++;
        txtCoincount.text = coinCount.ToString();
    }

    void RestartLevel()
    {
        //reload current Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nameNextScene);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

   
}


public static class UIExtensions
{
    public static void HideCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    
    public static void ShowCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}