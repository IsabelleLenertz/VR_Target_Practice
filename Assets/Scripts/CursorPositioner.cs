using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    public GameObject meMyselfEye;
    private float defaultPosZ;
    private MyInputyController input;
    private Vector3 hitpoint;

    void Start()
    {
        defaultPosZ = transform.localPosition.z;
        input = meMyselfEye.GetComponent<MyInputyController>();
    }

    void Update()
    {
        Transform controller = input.controllerPosition();// Get position of the controller
        RaycastHit hit;
        if (Physics.Raycast(controller.position, controller.forward, out hit, 100)) // Cast a ray and saves the hit point and object
        {
            hitpoint = hit.point;
            transform.position = hitpoint; // Change the position of the reticle to the hit point
            Vector3.MoveTowards(transform.position, controller.position, 0.05f); // Push the point just a little closer to the controller to make sure it is not hidden by the target
        }
    }
}