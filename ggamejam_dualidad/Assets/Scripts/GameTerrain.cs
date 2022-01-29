using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTerrain : MonoBehaviour
{
    public Cell cell;

    public int width = 1;
    public int length = 1;

    public float cellOffsetX = 0;
    public float cellOffsetZ = 0;

    private Cell[,] cells;

    // Start is called before the first frame update
    void Start()
    {
        cells = new Cell[width, length];
        var first = gameObject.transform.position;

        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                cells[i, j] = Instantiate<Cell>(cell, new Vector3(first.x + i * cellOffsetX, first.y, first.z + j * cellOffsetZ), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
