using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RightController : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject gunModel;
    public GameObject controllerModel;
    public GameObject teleportationSystem;
    public GameObject reticleCursor;
    public GameObject WindshieldCanvas;
    public Text scoreDisplay;

    private bool hasGun;

    private MyInputyController input;
    private int totalTargets;


    // Use this for initialization
    void Start () {
        input = mainCamera.GetComponent<MyInputyController>();
        hasGun = false;

        // Get the number of targets at the begining
        GameObject[] targets = GameObject.FindGameObjectsWithTag("target");
        totalTargets = targets.Length;
        CursorPositioner.score = 0;
    }

    // Update is called once per frame
    void Update () {

        // Update the score
        scoreDisplay.text = "Target Destroyed: " + CursorPositioner.score + "/" + totalTargets;

        // Handle the controls
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

        if (input.RightMenuButtonDown())
        {
            if (WindshieldCanvas.gameObject.activeInHierarchy)
            {
                WindshieldCanvas.gameObject.SetActive(false);
            } else
            {
                WindshieldCanvas.gameObject.SetActive(true);
            }
        }
    }
}
