using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{

    public GameTerrain terrain;
    public PlayerController PlayerController;
    public EnemyController  EnemyController;
    public Vector2Int PlayerPos;
    public Vector2Int EnemyPos;

    public PlayerController player;
    public EnemyController enemy;

    void Start()
    {
        int terrainMaxCoordX = terrain.width - 1;
        int terrainMaxCoordY = terrain.length - 1;

        int PlayerX = Random.Range(0, terrainMaxCoordX); //filas
        int PlayerY = Random.Range(0, terrainMaxCoordY / 2); //columnas

        int EnemyX = Random.Range(0, terrainMaxCoordX);
        int EnemyY = Random.Range(terrainMaxCoordY / 2 + 1, terrainMaxCoordY);
        
        PlayerPos = new Vector2Int(PlayerX,PlayerY);
        EnemyPos = new Vector2Int(EnemyX,EnemyY);

        Vector3 PosicionMundoCeldaPlayer = terrain.cells[PlayerX,PlayerY].position.transform.position;
        Vector3 PosicionMundoCeldaEnemy = terrain.cells[EnemyX,EnemyY].position.transform.position;

        player = Instantiate<PlayerController>(PlayerController, PosicionMundoCeldaPlayer, Quaternion.identity);
        enemy = Instantiate<EnemyController>(EnemyController, PosicionMundoCeldaEnemy, Quaternion.identity);

        // Movement Constraints
        player.minCoord = new Vector2Int(0, 0);
        player.maxCoord = new Vector2Int(terrainMaxCoordX, terrainMaxCoordY / 2);

        enemy.minCoord = new Vector2Int(0, terrainMaxCoordY / 2 + 1);
        enemy.maxCoord = new Vector2Int(terrainMaxCoordX, terrainMaxCoordY);
    }
}
