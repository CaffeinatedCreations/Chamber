using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{

    public int playerID;
    public Vector2 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
