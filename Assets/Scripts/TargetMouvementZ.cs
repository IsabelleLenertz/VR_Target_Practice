﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMouvementZ : MonoBehaviour {
    private Vector3 initialPos;
    public float speed = 10f;
    public float maxDistance = 20f;

    // Use this for initialization
    void Start () {
        initialPos = this.GetComponent<Transform>().position;

    }

    // Update is called once per frame
    void Update () {
        // moves along the z axis
        if (Vector3.Distance(initialPos, this.GetComponent<Transform>().position) < maxDistance)
        {
            Vector3 position = this.GetComponent<Transform>().position;
            position.z += Time.deltaTime * speed;
            this.GetComponent<Transform>().position = position;
        }
        else
        {
            speed *= -1;
            Vector3 position = this.GetComponent<Transform>().position;
            position.z += Time.deltaTime * speed;
            this.GetComponent<Transform>().position = position;
        }
    }
}
