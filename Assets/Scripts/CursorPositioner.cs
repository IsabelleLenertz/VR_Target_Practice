using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    public GameObject meMyselfEye;
    private float defaultPosZ;
    private MyInputyController input;

    void Start()
    {
        defaultPosZ = transform.localPosition.z;
        input = meMyselfEye.GetComponent<MyInputyController>();
    }

    void Update()
    {
        Transform controller = input.controllerPosition();
        Ray ray = new Ray(controller.position, controller.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.localPosition = new Vector3(0, 0, hit.distance);
        }
    }
}