using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider2D;
    private bool isGrounded = true;
    private Vector3 startPosition;
    private float elapsedTimeTrigger = 0f;

    public delegate void Death();
    public Death DeathHandler { get; set; }

    private GameManager gameManager;
    [SerializeField] private GameObject playerPrefab;                    
    [SerializeField] private float jumpForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        DeathHandler = SpawnPlayerAfterDeath;
        startPosition = transform.position;
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

        elapsedTimeTrigger += Time.deltaTime;
    }

    //cube jump when player touch display
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        isGrounded = false;
    }

    //when cube collision with obstacle, he teleport to the spawn point
    private void SpawnPlayerAfterDeath()
    {
        gameManager.ReturnPositionMap();
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle" && elapsedTimeTrigger >=0.1)
        {
            DeathHandler();
            elapsedTimeTrigger = 0;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            isGrounded = false;
        }
    }


}
