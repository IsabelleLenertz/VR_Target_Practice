using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pointer : MonoBehaviour {

    //controller position
    private MyInputyController input;
    public GameObject MainCamera;


    // Variables for the laser
    private SteamVR_TrackedObject trackedObj;
    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;

    // Use this for initialization
    void Start () {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        input = MainCamera.GetComponent<MyInputyController>();
    }

    // Update is called once per frame
    void Update () {

        RaycastHit hit;
        Transform controller = input.controllerPosition();
        if (Physics.Raycast(controller.position, controller.forward, out hit, 100))
        {
            hitPoint = hit.point;
            ShowLaser(hit);

            // Check if the user selects an item
            if (input.RightTriggerDown())
            {
                GameObject hitObj = hit.transform.gameObject;
                if (hitObj.tag == "Level_1")
                {
                    // Load new scene
                    SceneManager.LoadScene("Level_2");
                } else if (hitObj.tag == "Shooting_Tutorial")
                {
                    // Load new scene
                    SceneManager.LoadScene("Shooting_Tutorial");
                } else if (hitObj.tag == "Teleportation_Tutorial")
                {
                    // Load new scene
                    SceneManager.LoadScene("Teleportation tutorial");
                }


            }
        }
        else
        {
            laser.SetActive(false);
        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(input.controllerPosition().position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);
    }
}
