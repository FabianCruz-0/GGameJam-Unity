using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public Obstacle obstaclePrefab;
    public int maxObstacles = 10;

    public GameTerrain terrain;
    public PlayerController PlayerController;
    public EnemyController EnemyController;
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

        PlayerPos = new Vector2Int(PlayerX, PlayerY);
        EnemyPos = new Vector2Int(EnemyX, EnemyY);

        var playerCell = terrain.cells[PlayerX, PlayerY];
        var enemyCell = terrain.cells[EnemyX, EnemyY];
        Vector3 PosicionMundoCeldaPlayer = playerCell.position.transform.position;
        Vector3 PosicionMundoCeldaEnemy = enemyCell.position.transform.position;
        playerCell.value = 1;
        enemyCell.value = 1;

        player = Instantiate<PlayerController>(PlayerController, PosicionMundoCeldaPlayer, Quaternion.identity);
        enemy = Instantiate<EnemyController>(EnemyController, PosicionMundoCeldaEnemy, Quaternion.identity);

        // Movement Constraints
        player.minCoord = new Vector2Int(0, 0);
        player.maxCoord = new Vector2Int(terrainMaxCoordX, terrainMaxCoordY / 2);

        enemy.minCoord = new Vector2Int(0, terrainMaxCoordY / 2 + 1);
        enemy.maxCoord = new Vector2Int(terrainMaxCoordX, terrainMaxCoordY);

        ResetObstacles();
    }

    void ResetObstacles()
    {
        int totalObstacles = Random.Range(0, maxObstacles);
        for (int i = 0; i < totalObstacles; i++)
        {
            var obstacle = Instantiate<Obstacle>(obstaclePrefab, transform);
            obstacle.terrain = terrain;

            int terrainMaxCoordX = terrain.width - 1;
            int terrainMaxCoordY = terrain.length - 1;

            int randomX = Random.Range(0, terrainMaxCoordX);
            int randomY = Random.Range(0, terrainMaxCoordY);

            var randomCoordinate = new Vector2Int(randomX, randomY);
            
            while(terrain.cells[randomX, randomY].value != 0)
            {
                randomX = Random.Range(0, terrainMaxCoordX);
                randomY = Random.Range(0, terrainMaxCoordY);

                randomCoordinate = new Vector2Int(randomX, randomY);
            }

            obstacle.MatrixPosition = randomCoordinate;
        }
    }
}
