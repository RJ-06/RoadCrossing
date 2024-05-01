using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    public PedestrianNode currentNode;
    public PedestrianNode nextNode;
    private Rigidbody rb;

    [SerializeField] float randomOffsetpVal;
    private Vector3 randomOffsetPos;
    [SerializeField] float rSpeedChange;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        choosePath(currentNode);
    }

    // Update is called once per frame
    void Update()
    {
        moveToNextNode();

    }



    public void choosePath(PedestrianNode p)
    {
        //randomly chooses which node to go to (allows for multiple lanes
        PedestrianNode[] posPoints = p.tpossiblePoints.ToArray();
        nextNode = posPoints[Random.Range(0, posPoints.Length)];
        randomOffsetPos = new Vector3(Random.Range(-randomOffsetpVal, randomOffsetpVal),0,Random.Range(-randomOffsetpVal, randomOffsetpVal));
        speed += Random.Range(-rSpeedChange, rSpeedChange);
    }

    public void OnTriggerEnter(Collider col)
    {
        //gets which node its touching
        currentNode = col.GetComponent<PedestrianNode>();
        if (currentNode == null)
            return;

        choosePath(currentNode);
        //allows changing car speed based on where it is
        speed = currentNode.speed;

    }
    
    public void moveToNextNode()
    {
        //moves to position, rotates car
        if (!nextNode.canMoveTo)
            return;

        
        transform.position = Vector3.MoveTowards(this.transform.position, nextNode.transform.position + randomOffsetPos, speed * Time.deltaTime);
        transform.LookAt(nextNode.transform.position);
    }

    public Rigidbody getrb()
    {
        return rb;
    }
}
