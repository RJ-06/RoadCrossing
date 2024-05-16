using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float sensX;
    [SerializeField] float sensY;
    [SerializeField] float rotationYLock;
    [SerializeField] Transform orientation;

    public static float mouseX;
    public static float mouseY;

    float xRot;
    float yRot;

    [SerializeField] PlayerInput pInput;
    InputAction cameraAction;

    void Start()
    {

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        cameraAction = pInput.actions.FindAction("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) //for debugging
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        //mouseX = cameraAction.ReadValue<Vector2>().x * Time.deltaTime * sensX;
        //mouseY = cameraAction.ReadValue<Vector2>().y * Time.deltaTime * sensY;
        mouseX *= Time.deltaTime * sensX;
        mouseY *= Time.deltaTime * sensX;
        /*float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;*/
        yRot += mouseX;
        xRot -= mouseY;

        xRot = Mathf.Clamp(xRot, -rotationYLock,rotationYLock); //clamps how much you can look

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);

    }
}
