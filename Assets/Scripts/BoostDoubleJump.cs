using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDoubleJump : MonoBehaviour
{
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.isBoosted = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.isBoosted = false;
        }
    }


}
