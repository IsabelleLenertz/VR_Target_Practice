using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;
    private SteamVR_TrackedObject trackedObj;

    // Use this for initialization
    void Start () {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }


    // Update is called once per frame
    void Update () {
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            RaycastHit hit;

            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                GameObject objectHit = hit.transform.gameObject; // for future use, check if target
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
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, 0.5f);
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
}
