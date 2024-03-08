using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //control physics
    private CharacterController charController;

    [SerializeField] float playerSpeed;

    private float moveX;
    private float moveY;
    Vector3 moveDirecion;
    [SerializeField] Transform orientation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        charController = GetComponent<CharacterController>();
        rb.freezeRotation = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        myInput();
    }
    
    //fixedUpdate runs a fixed amount of times per second, so is used for physics
    private void FixedUpdate()
    {
        movePlayer();   
        
    }

    private void myInput() 
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer() 
    {
        moveDirecion = orientation.forward * moveY + orientation.right * moveX;
        rb.velocity = (moveDirecion.normalized * playerSpeed);
    }
}
