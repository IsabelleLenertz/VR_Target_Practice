using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject gunModel;
    public GameObject controllerModel;
    public GameObject teleportationSystem;
    public GameObject reticleCursor;

    private bool hasGun;

    private MyInputyController input;


    // Use this for initialization
    void Start () {
        input = mainCamera.GetComponent<MyInputyController>();
        hasGun = false;
    }

    // Update is called once per frame
    void Update () {
        if (input.RightHairGripDown())
        {
            if (hasGun)
            {
                // Hide gun show controller
                gunModel.gameObject.SetActive(false);
                controllerModel.gameObject.SetActive(true);
                reticleCursor.gameObject.SetActive(false);
                teleportationSystem.gameObject.SetActive(true);
                hasGun = false;
            }
            else
            {
                // Hide controller show gun
                gunModel.gameObject.SetActive(true);
                controllerModel.gameObject.SetActive(false);
                reticleCursor.gameObject.SetActive(true);
                teleportationSystem.gameObject.SetActive(false);
                hasGun = true;
            }
        }
    }
}
