using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    public GameObject meMyselfEye;
    public SteamVR_TrackedObject rightHand;
    public static int score;


    private float defaultPosZ;
    private MyInputyController input;
    private Vector3 hitpoint;
    private const int pointsPerTarget = 1;



    void Start()
    {
        defaultPosZ = transform.localPosition.z;
        input = meMyselfEye.GetComponent<MyInputyController>();
        score = 0;
    }

    void Update()
    {
        input.RightTriggerDown();
        Transform controller = input.controllerPosition();// Get position of the controller
        RaycastHit hit;
        if (Physics.Raycast(controller.position, controller.forward, out hit, 100)) // Cast a ray and saves the hit point and object
        {
            this.gameObject.GetComponent<Canvas>().enabled = true;
            hitpoint = hit.point;
            transform.position = hitpoint; // Change the position of the reticle to the hit point
            Vector3.MoveTowards(transform.position, controller.position, 0.05f); // Push the point just a little closer to the controller to make sure it is not hidden by the target

            // Check if the user shoots
            if (input.RightTriggerDown())
            {
                GameObject hitObj = hit.transform.gameObject;
                if(hitObj.tag == "target")
                {
                    rightHand.GetComponent<AudioSource>().Play();
                    Destroy(hitObj);
                    score += pointsPerTarget;
                }

            }
        } else
        {
            this.gameObject.GetComponent<Canvas>().enabled = false;
        }
    }
}