using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Animator animator;
   
    private Rigidbody rb;
    private bool isGrounded = true;
    float horizontalInput;
    float verticalInput;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        control();
        Animation_Control();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void control()
    {
        // Zýplama
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Eðilme
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouched", true);

           
        }
        else
        {
            animator.SetBool("Crouched", false);
        }


        // Hýzlý koþma ve Normal koþma
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f;
        moveDirection.Normalize();

        // Kameranýn yatay dönüþünü alarak karakteri döndür
        float cameraRotation = Camera.main.transform.rotation.eulerAngles.y;
        
        Quaternion rotation = Quaternion.Euler(0, cameraRotation, 0);
        rb.MoveRotation(rotation);

        // Hareketi uygula
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement) ;

        // Hýzlý koþma kontrolü
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Sprint", true);
            movement *= 3f; // Hýzlý koþma hýzýný artýrabiliriz.
        }
        else

        {
            animator.SetBool("Sprint", false);

        }

    }
    void Animation_Control()
    {
        if (verticalInput > 0)
        {
            animator.SetBool("IsRunningForward", true);
            //Roll
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                animator.SetTrigger("Roll");

            }

        }
        else if (verticalInput < 0)
        {
            animator.SetBool("IsRunningBackward", true);
        }
        else if (verticalInput == 0)
        {
            animator.SetBool("IsRunningForward", false);
            animator.SetBool("IsRunningBackward", false);
        }

        if (horizontalInput < 0)
        {
            animator.SetBool("IsRunningLeft", true);
        }

        else if (horizontalInput > 0)
        {
            animator.SetBool("IsRunningRight", true);
        }
        else if (horizontalInput == 0)
        {
            animator.SetBool("IsRunningLeft", false);
            animator.SetBool("IsRunningRight", false);
        }
    }
    
}

