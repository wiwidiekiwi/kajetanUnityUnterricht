using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILevelManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelWin;
    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonPlayAgainWin;
    
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private Button buttonPlayAgainLose;

    [SerializeField] private string nameNextScene;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        
        //win and lose screen -> hide

        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();
        
        buttonPlayAgainWin.onClick.AddListener(RestartLevel);
        buttonPlayAgainLose.onClick.AddListener(RestartLevel);
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
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