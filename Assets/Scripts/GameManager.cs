using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    [SerializeField] private float speedMap;

    private Vector3 startPositionX;

    // Start is called before the first frame update
    void Start()
    {
        startPositionX = floor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MapMove();
    }

    //the map moves creating the illusion of cube movement
    private void MapMove()
    {
        floor.transform.Translate(Vector2.left * Time.deltaTime * speedMap);
    }

    //When player die, map return to the start position 
    public void ReturnPositionMap()
    {
        floor.transform.position = startPositionX;
    }
}
