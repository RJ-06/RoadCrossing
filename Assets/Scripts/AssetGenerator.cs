using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]

[CustomEditor(typeof(SceneDecoration))]
public class AssetGenerator : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SceneDecoration sceneDecoration = (SceneDecoration)target;

        sceneDecoration.count = (int)EditorGUILayout.Slider("Object count", sceneDecoration.count, 0, 40);
        sceneDecoration.radius = EditorGUILayout.Slider("Placement radius", sceneDecoration.radius, 0, 10);

        if (GUILayout.Button("Generate Assets"))
        {
            generateAssets(sceneDecoration);
        }
        if (GUILayout.Button("Reset Assets")) 
        {
            resetAssets(sceneDecoration);
        }
    }

    void generateAssets(SceneDecoration s) 
    {

        for(int i = 0; i < s.count; i++) 
        {
            s.objects.Add(Instantiate(s.assets[Random.Range(0, s.assets.Length-1)],
                new Vector3(s.transform.position.x + Random.Range(-s.radius,s.radius), s.transform.position.y, s.transform.position.z + Random.Range(-s.radius, s.radius)),
                Quaternion.identity,s.transform));
            s.objects[i].transform.Rotate(Vector3.up,Random.Range(0,360));
        }
    }

    void resetAssets(SceneDecoration s) 
    {
        while (s.objects.Count > 0) 
        {
            DestroyImmediate(s.objects[0]);
            s.objects.RemoveAt(0);
        }


        /*for(int i = s.count-1; i >=0; i++) 
        {
            var temp = s.objects[i];
            s.objects[i] = null;
            Destroy(temp);
        }*/
    }

}
