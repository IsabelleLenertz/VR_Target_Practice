using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInputyController : MonoBehaviour {

    public SteamVR_TrackedObject rightHand;
    private SteamVR_Controller.Device device;
    public MyInputAction myInput;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (RightTriggerDown())
        {
            myInput.buttonAction = MyInputAction.ButtonAction.PressedDown;
        } else if (RightTriggerUp())
        {
            myInput.buttonAction = MyInputAction.ButtonAction.ReleasedUp;
        }
        else
        {
            myInput.buttonAction = MyInputAction.ButtonAction.None;
        }
	}

    public bool RightTriggerDown()
    {
        device = SteamVR_Controller.Input((int)rightHand.index);
        if(device != null && device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            device.TriggerHapticPulse(700);
            return true;
        }
        return false;
    }

    public bool RightTriggerUp()
    {
        device = SteamVR_Controller.Input((int)rightHand.index);
        if (device != null && device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            return true;
        }
        return false;
    }
}
