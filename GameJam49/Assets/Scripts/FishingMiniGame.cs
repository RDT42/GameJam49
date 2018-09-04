﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class FishingMiniGame : MonoBehaviour {
    GameObject pole, fish;
    GameObject catchit, caughtit;
    bool onLine, caught;
    Random rnd = new Random();
    Stopwatch stp = new Stopwatch();
    float startPos;

    // Use this for initialization
    void Start () {
        pole = GameObject.FindGameObjectWithTag("FishingPole");
        fish = GameObject.FindGameObjectWithTag("Fish");
        catchit = GameObject.FindGameObjectWithTag("CatchItText");
        catchit.SetActive(false);
        caughtit = GameObject.FindGameObjectWithTag("CaughtText");
        caughtit.SetActive(false);
        fish.SetActive(false);
        startPos = pole.transform.position.y;
        onLine = false;
        caught = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0,350) == 1 && !onLine && !caught)
        {
            catchit.SetActive(true);
            onLine = true;
            fish.SetActive(true);
            stp.Start();
        }

        if (onLine && !caught)
        {
            pole.transform.Translate(new Vector3(0, -0.02f, 0));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                pole.transform.Translate(new Vector3(0, 0.25f, 0));
            }

            if (pole.transform.position.y >= 1.8f)
            {
                // GIVE PLAYER RANDOM FISH
                Random.Range(10,25);
                onLine = false;
                caught = true;
                catchit.SetActive(false);
                caughtit.SetActive(true);
            }
        }        
	}
}
