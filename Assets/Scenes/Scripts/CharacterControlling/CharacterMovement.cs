using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private int counter = 0;
    private int JumpCounter = 0;
    private int MoveCounter = 0;
    private int SprintCounter = 0;
    private int SneakCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start!");
    }

    // Update is called once per frame
    void Update()
    {
       // counter = counter + 1;
       // Debug.Log("Update! Framenumber: " + counter);
    }

    void OnJump()
    {
        JumpCounter = JumpCounter + 1;
        Debug.Log("Jump! " + JumpCounter);
    }

    void OnMove()
    {
        MoveCounter = MoveCounter + 1;
        Debug.Log("Move! " + MoveCounter);
    }

    void OnSprint()
    {
        SprintCounter = SprintCounter + 1;
        Debug.Log("Sprint! " + SprintCounter);
    }

    void OnSneak()
    {
        SneakCounter = SneakCounter + 1;
        Debug.Log("Sneak! " + SneakCounter);
    }
}
