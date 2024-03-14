using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    public RoadNode currentNode;
    public RoadNode nextNode;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        choosePath();
    }

    // Update is called once per frame
    void Update()
    {
        if(nextNode != null)
            moveToNextNode();
    }



    public void choosePath() 
    {
        //randomly chooses which node to go to (allows for multiple lanes
        RoadNode[] posPoints = currentNode.tpossiblePoints.ToArray();
        nextNode = posPoints[Random.Range(0, posPoints.Length)];
    }

    public void OnTriggerEnter(Collider col)
    {
        //gets which node its touching
        currentNode = col.GetComponent<RoadNode>();
        choosePath();
        //allows changing car speed based on where it is
        speed = currentNode.speed;
        
    }

    public void moveToNextNode()
    {
        //moves to position, rotates car
        transform.position = Vector3.MoveTowards(this.transform.position,nextNode.transform.position,speed * Time.deltaTime);
        transform.LookAt(nextNode.transform.position);
    }

    public Rigidbody getrb() 
    {
        return rb;
    }
}
