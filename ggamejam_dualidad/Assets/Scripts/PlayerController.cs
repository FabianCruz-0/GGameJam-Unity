using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterClass
{
    public GameObject terreno;
    void Start()
    {
        
    }
    void Update()
    {
        movement();
    }

    void movement()
    {
    //     if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
    //     {
    //         Debug.Log("MOVEMENT GOES UP");
    //         matrixPosition -= new Vector2(1, 0);
    //         Debug.Log(matrixPosition);
    //         //this.transform.position = celda[matrixPosition.x,matrixPosition.y].transform.position;
    //     }

    //     if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
    //     {
    //         Debug.Log("MOVEMENT GOES RIGHT");
    //         position += new Vector2(0, 1);
    //         Debug.Log(position);
    //     }

    //     if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
    //     {
    //         Debug.Log("MOVEMENT GOES DOWN");
    //         position += new Vector2(1, 0);
    //         Debug.Log(position);
    //     }

    //     if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
    //     {
    //         Debug.Log("MOVEMENT GOES LEFT");
    //         position -= new Vector2(0, 1);
    //         Debug.Log(position);
    //     }
    // }
    }
}
