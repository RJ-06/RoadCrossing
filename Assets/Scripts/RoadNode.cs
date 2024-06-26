using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadNode : MonoBehaviour
{
    // Start is called before the first frame update
    public List<RoadNode> allPossiblePoints; //all connected points
    public bool canMoveTo = true;
    public float speed;

    [SerializeField] float detectionRadius;
    [SerializeField] SphereCollider s;

    public List<RoadNode> tpossiblePoints; //true points the car can go to

    public Car carAtNode;



    void Start()
    {
        s = GetComponent<SphereCollider>();
        s.radius = detectionRadius;
        s.isTrigger = true;

        foreach (RoadNode node in allPossiblePoints) //array of only places the player can move to
        {
            if(node.canMoveTo)
                tpossiblePoints.Add(node);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        carAtNode = other.GetComponent<Car>();
        if (carAtNode == null)
            return;

        canMoveTo = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Car>() == null)
            return;

        carAtNode = null;
        canMoveTo = true;
    }
}
