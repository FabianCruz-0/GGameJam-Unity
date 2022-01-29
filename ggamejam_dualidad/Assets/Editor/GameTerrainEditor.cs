using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameTerrain))]
public class GameTerrainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameTerrain terrain = (GameTerrain)target;

        if(GUILayout.Button("Build Terrain"))
        {
            terrain.BuildTerrain();
        }
    }
}
