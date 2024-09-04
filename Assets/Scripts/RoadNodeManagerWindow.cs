using UnityEngine;
using UnityEditor;

public class RoadNodeManagerWindow : EditorWindow
{

    GameObject NodeToPlace;
    GameObject lastNode = null;
    GameObject street;


    [MenuItem("Window/RoadNodes")]
    public static void ShowWindow() 
    {
        GetWindow<RoadNodeManagerWindow>("RoadNodes");
    }

    private void OnGUI()
    {
        GUILayout.Label("Use to place RoadNodes easily");
        GUILayout.Label("sample node");
        NodeToPlace = EditorGUILayout.ObjectField(NodeToPlace, typeof(GameObject), true) as GameObject;
        
        GUILayout.Label("street - empty object");
        street = EditorGUILayout.ObjectField(street, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("Place Node")) 
        {
            onPlaceNode();
        }

    }
    void onPlaceNode() 
    {

        GameObject tempNode = Instantiate(NodeToPlace, street.transform.position, Quaternion.identity,street.transform);
        Debug.Log(lastNode);
        if (lastNode != null)
        {
            RoadNode ln = lastNode.GetComponent<RoadNode>();
            ln.allPossiblePoints.Add(tempNode.GetComponent<RoadNode>());
            tempNode.transform.position = lastNode.transform.position;

        }
        lastNode = tempNode;
        Debug.Log(lastNode);

    }
}
