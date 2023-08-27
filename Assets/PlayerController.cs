using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Animator animator;//animasyon yok zaten cube ama ben yine animator ald�m

    private Rigidbody rb;
    private bool isGrounded = true;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();//animasyon yok zaten cube ama ben yine animator ald�m
    }

    private void Update()
    {

        // Z�plama
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // E�ilme
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // Animasyonla yapmak laz�m san�r�m :)
        }

        // H�zl� ko�ma ve Normal ko�ma
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;

        // H�zl� ko�ma kontrol�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= 1.5f; // H�zl� ko�ma h�z�n� art�rabiliriz.
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

