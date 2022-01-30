using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterClass
{

    public PlayerController player;

    void Start()
    {
        match = GameObject.Find("Match");
        terrain = GameObject.FindObjectOfType<GameTerrain>();
        player = GameObject.FindObjectOfType<PlayerController>();

        matrixPosition = match.GetComponent<Match>().EnemyPos;
    }

    void Update()
    {
        if(player.actions > 0 )
        {
            movement();
        }
    }

    void movement()
    {
        bool positionChanged = false;
        var nextPosition = matrixPosition;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            nextPosition += new Vector2Int(1, 0);
            positionChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            nextPosition -= new Vector2Int(0, 1);
            positionChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            nextPosition -= new Vector2Int(1, 0);
            positionChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            nextPosition += new Vector2Int(0, 1);
            positionChanged = true;
        }

        if (positionChanged)
        {
            MoveToCell(nextPosition);
        }
    }
}
