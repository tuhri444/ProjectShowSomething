using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomEventSystem))]
public class EventSystemEditor : Editor
{
    bool ShowPrefabList;
    List<bool> prefabs;
    public override void OnInspectorGUI()
    {
        CustomEventSystem myTarget = (target) as CustomEventSystem;
        if (myTarget.editorSaveSpace == null) myTarget.editorSaveSpace = new List<bool>();
        if (prefabs == null) prefabs = myTarget.editorSaveSpace;
        if (myTarget.Prefabs == null) myTarget.Prefabs = new List<GameObject>();
        myTarget.HotFixCondition = EditorGUILayout.ObjectField(myTarget.HotFixCondition, typeof(GameObject)) as GameObject;

        ShowPrefabList = EditorGUILayout.Foldout(ShowPrefabList, "Show Events");
        if (ShowPrefabList && prefabs.Count >0) RenderPrefabList(myTarget);
        GUI.color = Color.green;
        if (GUILayout.Button("Create Event Slot"))
        {
            prefabs.Add(false);
            GameObject go = new GameObject();
            go.transform.parent = myTarget.transform;
            myTarget.Prefabs.Add(go);
            go.AddComponent<CleanUp>();
        }
        GUI.color = Color.red;
        if (GUILayout.Button("Remove Event Slot"))
        {
            GameObject go;
            if(prefabs.Count != 0)
            {
                if(prefabs.Count == 1)
                {
                    go = myTarget.Prefabs[0];
                    myTarget.Prefabs.RemoveAt(0);
                    prefabs.RemoveAt(0);
                    if(go == null)
                        DestroyImmediate(go);
                }
                else
                {
                    go = myTarget.Prefabs[prefabs.Count - 1];
                    myTarget.Prefabs.RemoveAt(prefabs.Count - 1);
                    prefabs.RemoveAt(prefabs.Count-1);
                    if (go == null)
                        DestroyImmediate(go);
                }
            }
        }

        //just a tiny bit of clean-up ;)
        CleanUp[] cleanUpList = myTarget.transform.GetComponentsInChildren<CleanUp>();
        if(cleanUpList != null)
        {
            for(int i = 0; i < cleanUpList.Length; i++)
            {
                DestroyImmediate(cleanUpList[i].transform.gameObject);
            }
        }


        myTarget.editorSaveSpace = prefabs;
        if (GUI.changed) 
        { 
            EditorUtility.SetDirty(myTarget);
        }
    }

    private void RenderPrefabList(CustomEventSystem es)
    {
        for(int i = 0; i < prefabs.Count;i++)
        {
            prefabs[i] = EditorGUILayout.Foldout(prefabs[i], "Prefab " + i);
            if(prefabs[i] && es.Prefabs.Count != 0)
            {
                es.Prefabs[i] = EditorGUILayout.ObjectField(es.Prefabs[i], typeof(GameObject)) as GameObject;
            } 
        }
    }
}
