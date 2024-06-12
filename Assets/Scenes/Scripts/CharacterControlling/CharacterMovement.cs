using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    // was used to count the inputs, in the moment not needed
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

   [SerializeField] private Transform groundCheckPosition;
   [SerializeField] private float groundCheckRadius;
   [SerializeField] private LayerMask layerGroundcheck;

   private bool isFacingRight = true;
    
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

    //physics based functions go into fixed updates
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputDirection * movementSpeed, rb.velocity.y);
    }
    void OnJump()
    {
        if (Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, layerGroundcheck))
        {
            rb.velocity = new Vector2(0f, jumpForce);
            Debug.Log("Jump! ");
        }
        
       // JumpCounter = JumpCounter + 1;
       
    }

    void OnMove(InputValue inputValue)
    {
       // MoveCounter = MoveCounter + 1;
        inputDirection = inputValue.Get<float>();
        Debug.Log("Move! " + inputDirection);

        if (inputDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (inputDirection < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        // it flips the way the character model is facing in the direction the character has last moved in
        Vector3 currentScale = transform.localScale;
        currentScale.x = currentScale.x * -1;
        transform.localScale = currentScale;
        // !isFacingRight is a shortcut to say isFacingRight is false
        isFacingRight = !isFacingRight;
    }

    void OnSprint(InputValue inputValue)
    {
        // maybe this function can be made by increasing the velocity the character gets
       // SprintCounter = SprintCounter + 1;
       float isSprinting = inputValue.Get<float>();
        Debug.Log("Sprint! " + isSprinting);
    }

    void OnSneak(InputValue inputValue)
    {
        // maybe this function can be made by scaling the character down
        //SneakCounter = SneakCounter + 1;
        float isSneaking = inputValue.Get<float>();
        Debug.Log("Sneak! " + isSneaking);
    }
    
    
}
