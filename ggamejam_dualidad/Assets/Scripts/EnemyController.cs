using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : CharacterClass
{

    public PlayerController player;
    public Text HealthText;

    void Start()
    {
        health=5;
        match = GameObject.Find("Match");
        terrain = GameObject.FindObjectOfType<GameTerrain>();
        player = GameObject.FindObjectOfType<PlayerController>();
        HealthText = GameObject.Find("EnemyHealth").GetComponent<Text>();

        matrixPosition = match.GetComponent<Match>().EnemyPos;
        ChangeDirection(Vector2Int.left);
    }

    void Update()
    {
        if(player.actions > 0 )
        {
            movement();
        }
    HealthText.text = "Enemy Health: "+ health;
    }

    void movement()
    {
        bool positionChanged = false;
        var nextPosition = matrixPosition;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            ChangeDirection(Vector2Int.down);
            nextPosition += new Vector2Int(1, 0);
            positionChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            ChangeDirection(Vector2Int.left);
            nextPosition -= new Vector2Int(0, 1);
            positionChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            ChangeDirection(Vector2Int.up);
            nextPosition -= new Vector2Int(1, 0);
            positionChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            ChangeDirection(Vector2Int.right);
            nextPosition += new Vector2Int(0, 1);
            positionChanged = true;
        }

        if (positionChanged)
        {
            MoveToCell(nextPosition);
        }
    }
}
