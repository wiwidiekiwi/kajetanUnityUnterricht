using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //private int counter = 0;
   // private int JumpCounter = 0;
   // private int MoveCounter = 0;
   // private int SprintCounter = 0;
   // private int SneakCounter = 0;

   private Rigidbody2D rb;
   private float inputDirection;

   // [] with alt gr + 8 & 9
   [SerializeField] private float movementSpeed = 10f;
   [SerializeField] private float jumpForce = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Start!");
    }

    // Update is called once per frame
    void Update()
    {
       // counter = counter + 1;
       // Debug.Log("Update! Framenumber: " + counter);
    }

    //physics based things go in there
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputDirection * movementSpeed, rb.velocity.y);
    }
    void OnJump()
    {
        rb.velocity = new Vector2(0f, jumpForce);
       // JumpCounter = JumpCounter + 1;
        Debug.Log("Jump! ");
    }

    void OnMove(InputValue inputValue)
    {
       // MoveCounter = MoveCounter + 1;
        inputDirection = inputValue.Get<float>();
        Debug.Log("Move! " + inputDirection);
    }

    void OnSprint(InputValue inputValue)
    {
       // SprintCounter = SprintCounter + 1;
       float isSprinting = inputValue.Get<float>();
        Debug.Log("Sprint! " + isSprinting);
    }

    void OnSneak(InputValue inputValue)
    {
        //SneakCounter = SneakCounter + 1;
        float isSneaking = inputValue.Get<float>();
        Debug.Log("Sneak! " + isSneaking);
    }
    
    
}
