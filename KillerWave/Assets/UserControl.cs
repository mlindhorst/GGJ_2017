using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour {

    public float movementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow) && transform.position.y < 15)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + movementSpeed, transform.position.z);
        }
	}
}
