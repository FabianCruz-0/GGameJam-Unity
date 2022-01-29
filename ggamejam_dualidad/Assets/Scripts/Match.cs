using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{

    public GameTerrain terrain;
    public PlayerController PlayerController;
    public EnemyController  EnemyController;

    void Start()
    {
        int PlayerX = Random.Range(0,terrain.width); //filas
        int PlayerY = Random.Range(0,terrain.length/2); //columnas

        int EnemyX = Random.Range(0,terrain.width);
        int EnemyY = Random.Range(terrain.length/2,terrain.length);
        
        Vector2 PlayerPos = new Vector2(PlayerX,PlayerY);
        Vector2 EnemyPos = new Vector2(EnemyX,EnemyY);

        Debug.Log(PlayerX);
        Debug.Log(PlayerY);
        Debug.Log(terrain.cells[PlayerX,PlayerY]);

        Vector3 PosicionMundoCeldaPlayer = terrain.cells[PlayerX,PlayerY].position.transform.position;
        Vector3 PosicionMundoCeldaEnemy = terrain.cells[EnemyX,EnemyY].position.transform.position;

        Instantiate<PlayerController>(PlayerController, PosicionMundoCeldaPlayer, Quaternion.identity);   
        Instantiate<EnemyController>(EnemyController, PosicionMundoCeldaEnemy, Quaternion.identity);   

        //new Vector3(terrain.cells[PlayerX,PlayerY].transform.position.x,terrain.cells[PlayerX,PlayerY].transform.position.y,0)

        /*
        + va a tomar el ancho y el largo de la matriz, genera una posión entre 0 y el maximo y se lo asigna al PLayer.
        + va a tomar el ancho y el largo de la matriz, genera una posión entre 0 y el maximo y se lo asigna al Enemigo.
        
        Una vez se tenga la posición que va a tener el Player y el Enemigo, se instancian los Prefab, tomando el transform.position de la celda 
        que corresponde la posición generada aleatoriamente.


        Asigna la referencia del terreno a la clase de Player (?)

        */

    }


}
