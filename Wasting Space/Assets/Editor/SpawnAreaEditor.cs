using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SpawnArea))]
public class SpawnAreaEditor : Editor
{ 
    private void OnSceneGUI()
    {
        SpawnArea myTarget = (target)as SpawnArea;
        SpawnArea.RenderCustomGizmo(myTarget, GizmoType.NotInSelectionHierarchy);
        
    }

    
}