using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
    public float scrollSpeed;
    // Use this for initialization
    void Start () {
        scrollSpeed = 2;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.left * scrollSpeed;
        if(transform.position.x < -500)
        {
            Destroy(gameObject);
        }
    }

}
