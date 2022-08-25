using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollider : MonoBehaviour
{
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Delegate. A collision is reported
    void OnTriggerEnter2D(Collider2D collision)
    {
        playerScript.DeathHandler();
    }


}
