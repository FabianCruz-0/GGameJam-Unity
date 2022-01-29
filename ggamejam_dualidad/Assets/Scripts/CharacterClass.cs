using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterClass : MonoBehaviour
{
    public Vector2 matrixPosition
    {
        get { return matrixPosition; }
        set { matrixPosition = value; }
    }
    public int health
    {
        get { return health; }
        set { health = value; }
    }
}