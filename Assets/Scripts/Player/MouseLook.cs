using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    } //start

    private void Update()
    {
        //unlock cursor if you press escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        //get mouse x input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //get mouse y input
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //set x rotation based on mouseY
        xRotation -= mouseY;
        //clamp the rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate the cam on x axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //rotate the player body on z axis
        playerBody.Rotate(Vector3.up * mouseX); 

    } //update

} //class
