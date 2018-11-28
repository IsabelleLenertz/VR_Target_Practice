using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endOfGame : MonoBehaviour {

    private int totalTargets;

	// Use this for initialization
	void Start () {
        // Get the number of targets at the begining
        GameObject[] targets = GameObject.FindGameObjectsWithTag("target");
        totalTargets = targets.Length;

    }

    // Update is called once per frame
    void Update () {
		if(CursorPositioner.score == totalTargets)
        {
            // Load the begining of the game
            SceneManager.LoadScene("Intro");
        }
    }
}
