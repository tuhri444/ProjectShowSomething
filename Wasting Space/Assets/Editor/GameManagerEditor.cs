using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    int spawnAreaAmount;
    bool showAreas;
    //GUIStyle Button;
    public override void OnInspectorGUI()
    {
        //Button = new GUIStyle(GUI.skin.button);
        //Button.normal.textColor = Color.black;
        GameManager myTarget = (target) as GameManager;
        myTarget.SpawnAreaPrefab = EditorGUILayout.ObjectField(myTarget.SpawnAreaPrefab, typeof(GameObject)) as GameObject;
        spawnAreaAmount = myTarget.SpawnAreas.Count;

        //if (myTarget.EventSystem == null) myTarget.EventSystem = myTarget.gameObject.AddComponent<CustomEventSystem>() as CustomEventSystem;

        GUI.color = Color.green;
        if (GUILayout.Button("Create SpawnArea"))
        {
            GameObject temp = Instantiate(myTarget.SpawnAreaPrefab);
            temp.transform.parent = myTarget.transform;
            myTarget.SpawnAreas.Add(temp.GetComponent<SpawnArea>());
        }
        GUI.color = Color.red;
        if (GUILayout.Button("Remove Last Created"))
        {
            if (spawnAreaAmount > 0)
            {
                DestroyImmediate(myTarget.SpawnAreas[myTarget.SpawnAreas.Count - 1].gameObject);
                myTarget.SpawnAreas.RemoveAt(myTarget.SpawnAreas.Count - 1);
            }
        }
        GUI.color = Color.white;
        showAreas = EditorGUILayout.Foldout(showAreas, "Show Areas");
        if (showAreas && spawnAreaAmount > 0)
        {
            for (int i = 0; i < myTarget.SpawnAreas.Count; i++)
            {
                myTarget.SpawnAreas[i] = (SpawnArea)EditorGUILayout.ObjectField(myTarget.SpawnAreas[i], typeof(SpawnArea));
            }
        }
        if (GUI.changed) { EditorUtility.SetDirty(myTarget); }
    }
}
