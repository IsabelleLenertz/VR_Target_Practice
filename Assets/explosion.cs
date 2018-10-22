using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    public GameObject explosionParticles;

	// Use this for initialization
	void Start () {
        explosionParticles.GetComponent<ParticleSystem>().Stop();
        Invoke("explode", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        explosionParticles.GetComponent<ParticleSystem>().Play();

    }

    void explode()
    {
        Destroy(this.gameObject);
    }
}
