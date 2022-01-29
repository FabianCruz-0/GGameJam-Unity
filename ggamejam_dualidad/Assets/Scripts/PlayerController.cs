using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterClass
{
    public GameTerrain terrain;
    GameObject match;
    void Start()
    {
        match = GameObject.Find("Match");
        terrain = GameObject.FindObjectOfType<GameTerrain>();

        matrixPosition = match.GetComponent<Match>().PlayerPos;
    }

    void Update()
    {
        movement();
    }

    void movement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("MOVEMENT GOES UP");
            matrixPosition -= new Vector2Int(1,0);
            this.transform.position = terrain.cells[matrixPosition.x,matrixPosition.y].position.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("MOVEMENT GOES RIGHT");
            matrixPosition += new Vector2Int(0,1);
            this.transform.position = terrain.cells[matrixPosition.x,matrixPosition.y].position.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("MOVEMENT GOES DOWN");
            matrixPosition += new Vector2Int(1,0);
            this.transform.position = terrain.cells[matrixPosition.x,matrixPosition.y].position.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("MOVEMENT GOES LEFT");
            matrixPosition -= new Vector2Int(0,1);
            this.transform.position = terrain.cells[matrixPosition.x,matrixPosition.y].position.transform.position;
        }
    }
}
