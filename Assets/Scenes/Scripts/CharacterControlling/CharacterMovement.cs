using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private int counter = 0;
    private int JumpCounter = 0;
    
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
}
