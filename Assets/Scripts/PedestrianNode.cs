using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianNode : MonoBehaviour
{
    public List<PedestrianNode> allPossiblePoints; //all connected points
    public bool canMoveTo = true;
    public float speed;

    [SerializeField] float detectionRadius; //detection radius needs to be larger due to the random offset allowed
    [SerializeField] SphereCollider s;

    public List<PedestrianNode> tpossiblePoints; //true points the car can go to

    public List<Person> peopleAtNode;



    void Start()
    {
        s = GetComponent<SphereCollider>();
        s.radius = detectionRadius;
        s.isTrigger = true;

        foreach (PedestrianNode node in allPossiblePoints) //array of only places the player can move to
        {
            /*if (node.canMoveTo)
                tpossiblePoints.Add(node);*/
            tpossiblePoints.Add(node);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Person p = other.GetComponent<Person>();
        if (p == null)
            return;

        peopleAtNode.Add(p);
        //canMoveTo = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Person>() == null)
            return;

        peopleAtNode.Remove(other.GetComponent<Person>());
        //canMoveTo = true;
    }
}
