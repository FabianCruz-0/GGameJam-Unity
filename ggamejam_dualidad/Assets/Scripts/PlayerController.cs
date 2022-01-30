using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterClass
{
    public GameTerrain terrain;
    GameObject match;
    public TurnsSystem turnsSystem;
    int actions;
    bool canMove;

    void Start()
    {
        actions = 5;
        canMove = true;
        match = GameObject.Find("Match");
        terrain = GameObject.FindObjectOfType<GameTerrain>();
        turnsSystem = GameObject.FindObjectOfType<TurnsSystem>();

        matrixPosition = match.GetComponent<Match>().PlayerPos;
    }

    void Update()
    {
        if (actions > 0 && canMove)
        {
            movement();
        } else {

            Debug.Log("Turn Finished.");
            turnsSystem.TurnNumber += 1;
            actions=5;
        }

    }

    void movement()
    {
        bool positionChanged = false;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("MOVEMENT GOES UP");
            matrixPosition -= new Vector2Int(1, 0);
            positionChanged = true;
            actions-=1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("MOVEMENT GOES RIGHT");
            matrixPosition += new Vector2Int(0, 1);
            positionChanged = true;
            actions-=1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("MOVEMENT GOES DOWN");
            matrixPosition += new Vector2Int(1, 0);
            positionChanged = true;
            actions-=1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("MOVEMENT GOES LEFT");
            matrixPosition -= new Vector2Int(0, 1);
            positionChanged = true;
            actions-=1;
        }

        if (positionChanged)
        {
            matrixPosition.Clamp(minCoord, maxCoord);
            transform.position = terrain.cells[matrixPosition.x, matrixPosition.y].position.transform.position;
        }
    }
}
