﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "My Objects/Input Action")]
public class MuInputAction : ScriptableObject
{
    public enum ButtonAction { None, PressedDown, ReleasedUp }
    public ButtonAction buttonAction;
}
