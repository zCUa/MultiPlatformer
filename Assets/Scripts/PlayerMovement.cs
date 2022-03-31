using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private PolygonCollider2D polygonCollider;
    private Animator animator;

    public float speed;
    public float jump;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        ActivePlayer();
    }


    private void ActivePlayer()
    {
        // Only allow one user to move at a time based on which one is active.
        if(CinemachineSwitcher.flag && gameObject.CompareTag("Player") || !CinemachineSwitcher.flag && gameObject.CompareTag("Male"))
        {
            Move();
        }
    }
    
    // Player Movement
    private void Move()
    {  
        transform.position = new Vector3(body.transform.position.x, body.transform.position.y, transform.position.z);

        // Variables for input from user
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");

        // Flip player when moving left or right. Only when enough input from joystick.
        if (horizontalInput > 0)
        {
            // Face correct direction
            transform.localScale = Vector3.one;

            // Run animation
            animator.SetBool("isRunning", true);
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        } else if (horizontalInput < 0) {
            // Flip player when moving
            transform.localScale = new Vector3(-1,1,1);

            // Run animation
            animator.SetBool("isRunning", true);
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        } else {
            // Possible more cases if user walks instead of runs
            animator.SetBool("isRunning", false);
        }
        

        if(verticalInput > 0 && body.velocity.y == 0)
        {
            Jump(jump);
        }
    }

    private void Jump(float jump)
    {
        body.AddForce(Vector2.up * jump);
        animator.SetTrigger("Jump");
    }
}
