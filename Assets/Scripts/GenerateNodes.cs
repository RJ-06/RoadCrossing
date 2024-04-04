using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNodes : MonoBehaviour
{
    public LineRenderer lr;
    private Vector3[] nodePoints;
    [SerializeField] RoadNode r;
    private List<RoadNode> nodes;

    [SerializeField] RoadNode[] ConnectionNodes;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.GetPositions(nodePoints);

        generateNodes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateNodes() 
    {
        foreach (Vector3 nodePos in nodePoints) 
        {
            RoadNode n = Instantiate(r,nodePos,transform.rotation);
            nodes.Add(n);
            
        }

        for(int i = 0; i < nodes.Count - 1; i++) 
        {
            nodes[i].allPossiblePoints.Add(nodes[i+1]);
        }

        //nodes[nodes.Count-1].allPossiblePoints = ConnectionNodes[];


        
    }
}
