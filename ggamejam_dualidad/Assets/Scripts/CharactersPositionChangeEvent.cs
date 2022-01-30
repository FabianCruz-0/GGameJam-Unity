using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersPositionChangeEvent : Event
{
    public override void Execute(Match match)
    {
        ChangeCharacterPosition(match);
    }

    void ChangeCharacterPosition(Match match)
    {
        var terrain = match.terrain;
        var terrainMaxCoordX = terrain.width - 1;
        var terrainMaxCoordY = terrain.length - 1;

        int PlayerX = Random.Range(0, terrainMaxCoordX); //filas
        int PlayerY = Random.Range(0, terrainMaxCoordY / 2); //columnas

        int EnemyX = Random.Range(0, terrainMaxCoordX);
        int EnemyY = Random.Range(terrainMaxCoordY / 2 + 1, terrainMaxCoordY);

        while (terrain.cells[PlayerX, PlayerY].value != 0)
        {
            PlayerX = Random.Range(0, terrainMaxCoordX); //filas
            PlayerY = Random.Range(0, terrainMaxCoordY / 2); //columnas
        }
        
        while (terrain.cells[EnemyX, EnemyY].value != 0)
        {
            EnemyX = Random.Range(0, terrainMaxCoordX);
            EnemyY = Random.Range(terrainMaxCoordY / 2 + 1, terrainMaxCoordY);
        }

        match.player.MoveToCell(new Vector2Int(PlayerX, PlayerY));
        match.enemy.MoveToCell(new Vector2Int(EnemyX, EnemyY));
    }
}
