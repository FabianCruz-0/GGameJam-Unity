using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterClass : MonoBehaviour
{
    public Vector2Int direction = Vector2Int.right;
    public Vector2Int matrixPosition;
    public int health;

    public Vector2Int minCoord;
    public Vector2Int maxCoord;

    public GameTerrain terrain;
    protected GameObject match;

    public void MoveToCell(Vector2Int coordinates)
    {
        coordinates.Clamp(minCoord, maxCoord);

        var currentCell = terrain.cells[matrixPosition.x, matrixPosition.y];
        var nextCell = terrain.cells[coordinates.x, coordinates.y];
        if (nextCell.value >= 0)
        {
            currentCell.value = 0;

            matrixPosition = coordinates;
            transform.position = nextCell.position.transform.position;

            nextCell.value = 1;
        }
    }

    public void ChangeDirection(Vector2Int newDirection)
    {
        direction = newDirection;

        if (direction == Vector2Int.up)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        else if (direction == Vector2Int.left)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (direction == Vector2Int.down)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (direction == Vector2Int.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}