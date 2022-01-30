using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharacterClass
{
    public TurnsSystem turnsSystem;
    public EventRoulette eventRoulette;
    public int actions;
    public bool canMove;
    public Text HealthText;

    void Start()
    {
        health = 5;
        actions = 5;
        canMove = true;
        match = GameObject.Find("Match");
        terrain = GameObject.FindObjectOfType<GameTerrain>();
        turnsSystem = GameObject.FindObjectOfType<TurnsSystem>();
        eventRoulette = GameObject.FindObjectOfType<EventRoulette>();
        HealthText = GameObject.Find("PlayerHealth").GetComponent<Text>();

        matrixPosition = match.GetComponent<Match>().PlayerPos;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            KeyPressed();
        }

        HealthText.text = "Player Health: "+ health;
    }

    void KeyPressed()
    {
        if (actions > 0)
        {
            movement();
        }
        else
        {
            if (canMove)
            {
                Debug.Log("Turn Finished.");
                eventRoulette.match.DestroyObjs();
                eventRoulette.match.objectsPos();
                eventRoulette.match.objectsInit();
                eventRoulette.match.ResetObstacles();
                canMove = false;
                eventRoulette.StartRoulette();
                turnsSystem.TurnNumber += 1;
            }
        }
    }

    void movement()
    {

        if (canMove == false)
        {
            return;
        }

        bool positionChanged = false;
        var nextPosition = matrixPosition;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            ChangeDirection(Vector2Int.up);
            nextPosition -= new Vector2Int(1, 0);
            positionChanged = true;
            actions -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            ChangeDirection(Vector2Int.right);
            nextPosition += new Vector2Int(0, 1);
            positionChanged = true;
            actions -= 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            ChangeDirection(Vector2Int.down);
            nextPosition += new Vector2Int(1, 0);
            positionChanged = true;
            actions -= 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            ChangeDirection(Vector2Int.left);
            nextPosition -= new Vector2Int(0, 1);
            positionChanged = true;
            actions -= 1;
        }

        if (positionChanged)
        {
            MoveToCell(nextPosition);
        }
    }
}
