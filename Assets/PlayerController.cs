using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Animator animator;//animasyon yok zaten cube ama ben yine animator aldým

    private Rigidbody rb;
    private bool isGrounded = true;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();//animasyon yok zaten cube ama ben yine animator aldým
    }

    private void Update()
    {

        // Zýplama
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Eðilme
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // Animasyonla yapmak lazým sanýrým :)
        }

        // Hýzlý koþma ve Normal koþma
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;

        // Hýzlý koþma kontrolü
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= 1.5f; // Hýzlý koþma hýzýný artýrabiliriz.
        }

        rb.MovePosition(transform.position + movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}

