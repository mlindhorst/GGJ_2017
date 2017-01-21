﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
    public int scrollSpeed;
    public static ObstacleMovement instance;
    // Use this for initialization
    void Start () {
        instance = this;
        scrollSpeed = 2;

	}
	
	// Update is called once per frame

	void Update () {

        if (gameObject.tag == "Cloud")
        {
            transform.position = transform.position + Vector3.right * .02f;
        }
        else
        {
            
            transform.position = transform.position + Vector3.left * scrollSpeed;
            if (transform.position.x < -500)
            {
                Destroy(gameObject);
            }
        }
    }

}
