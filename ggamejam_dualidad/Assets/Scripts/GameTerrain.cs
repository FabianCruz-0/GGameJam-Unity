using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTerrain : MonoBehaviour
{
    public Cell cellPrefab;

    public int width = 1;
    public int length = 1;

    public float cellOffsetX = 0;
    public float cellOffsetZ = 0;

    private Cell[,] cells;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Cell GetCellAt(int x, int y)
    {
        if(cells != null)
        {
            return cells[x, y];
        }

        return null;
    }

    public void BuildTerrain()
    {
        cells = new Cell[width, length];
        var first = transform.position;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                cells[i, j] = Instantiate<Cell>(cellPrefab, new Vector3(first.x + i * cellOffsetX, first.y, first.z + j * cellOffsetZ), Quaternion.identity);
                cells[i, j].transform.parent = transform;
            }
        }
    }
}
