using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMouvementCircles : MonoBehaviour {

    private Vector3 initialPos;
    private Vector3 center;
    public float speed = 10f;
    public float maxDistance = 20f;
    public float radius = 3f;
    private float teta = 0 ;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        initialPos = this.GetComponent<Transform>().position;
        center.x = initialPos.x + radius;
        center.y = initialPos.y;
        center.z = initialPos.z;
         
    }

    // Update is called once per frame
    void Update()
    {
        // the sphere turn in a circle
        teta += speed;
        Vector3 position = this.GetComponent<Transform>().position;
        position.x = radius * Mathf.Cos(teta);
        position.z = radius * Mathf.Sin(teta);
        this.GetComponent<Transform>().position = position;
    }
}

