using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameTerrain terrain;
    private Vector2Int _matrixPosition = new Vector2Int(-1, -1);
    public Vector2Int MatrixPosition
    {
        get { return _matrixPosition; }
        set
        {
            if (!terrain)
            {
                return;
            }

            if(_matrixPosition == new Vector2Int(-1, -1))
            {
                _matrixPosition = value;
                var cell = terrain.cells[_matrixPosition.x, _matrixPosition.y];
                transform.position = cell.position.transform.position;
                cell.value = -1;
                return;
            }

            var currentCell = terrain.cells[_matrixPosition.x, _matrixPosition.y];
            currentCell.value = 0;

            
            var nextCell = terrain.cells[value.x, value.y];
            transform.position = nextCell.position.transform.position;
            nextCell.value = -1;

            _matrixPosition = value;
        }
    }

    private void OnDestroy()
    {
        var currentCell = terrain.cells[_matrixPosition.x, _matrixPosition.y];
        currentCell.value = 0;
    }
}
