using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    private UILevelManager uiLevelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        uiLevelManager = FindObjectOfType<UILevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You Win!");
            uiLevelManager.OnGameWin();
        }

        if (other.CompareTag("DoNotTouch"))
        {
            Debug.Log("You Lose!");
            uiLevelManager.OnGameLose();
        }
    }

}
