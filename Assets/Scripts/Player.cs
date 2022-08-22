using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = true;

    [SerializeField] private float jumpForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if (isGrounded)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        isGrounded = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "floor")
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "floor")
        {
            isGrounded = false;
        }
    }


}
