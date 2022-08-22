using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    [SerializeField] private float speedMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MapMove();
    }

    private void MapMove()
    {
        floor.transform.Translate(Vector2.left * Time.deltaTime * speedMap);
    }
}
