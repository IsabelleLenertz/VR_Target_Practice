using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalloonController : MonoBehaviour {

    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    public float growRate = 1.5f;
    public MyInputAction myInput;

    private GameObject balloon;
    private MyInputyController inputController;
 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (myInput.buttonAction == MyInputAction.ButtonAction.PressedDown)
        {
            NewBalloon();
        } else if (myInput.buttonAction == MyInputAction.ButtonAction.ReleasedUp)
        {
            ReleaseBalloon();
        } else if(balloon != null)
        {
            GrowBalloon();
        }
	}

    private void NewBalloon()
    {
        balloon = Instantiate(balloonPrefab);
    }

    private void ReleaseBalloon()
    {
        balloon.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
        balloon = null;
    }

    private void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }
}
