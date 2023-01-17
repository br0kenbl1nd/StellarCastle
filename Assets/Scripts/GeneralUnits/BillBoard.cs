using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
    } //start 

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    } //late update

} //class
