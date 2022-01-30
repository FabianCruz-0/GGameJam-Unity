using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterClass
{
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
        bool positionChanged = false;
        var nextPosition = matrixPosition;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("MOVEMENT GOES UP");
            nextPosition -= new Vector2Int(1, 0);
            positionChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("MOVEMENT GOES RIGHT");
            nextPosition += new Vector2Int(0, 1);
            positionChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("MOVEMENT GOES DOWN");
            nextPosition += new Vector2Int(1, 0);
            positionChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("MOVEMENT GOES LEFT");
            nextPosition -= new Vector2Int(0, 1);
            positionChanged = true;
        }

        if (positionChanged)
        {
            MoveToCell(nextPosition);
        }
    }
}
