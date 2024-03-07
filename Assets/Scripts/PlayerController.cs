using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //control physics
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] float JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    //fixedUpdate runs a fixed amount of times per second, so is used for physics
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), rb.velocity.y, Input.GetAxisRaw("Vertical"));
        SphereCollider s = new SphereCollider(groundCheck,groundCheckRadius,true);

        rb.velocity = move;
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddForce(new Vector3(0, JumpForce, 0));
        }
        
    }
}
