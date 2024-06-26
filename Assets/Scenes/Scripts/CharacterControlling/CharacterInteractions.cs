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
        // if you touch something with the tag goal you win
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You Win!");
            uiLevelManager.OnGameWin();
        }
        // if you touch something with the tag donottouch you lose
        else if (other.CompareTag("DoNotTouch"))
        {
            Debug.Log("You Lose!");
            uiLevelManager.OnGameLose();
        }
        // if you touch something with the tag coin you get a coin
        else if (other.CompareTag("Coin"))
        {
            uiLevelManager.AddCoin();
            Destroy(other.gameObject);
        }
    }

}
