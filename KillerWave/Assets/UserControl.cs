using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour {

    public float movementSpeed;
    private DropPowerManager _dropPowerManager;

    // Use this for initialization
    void Start () {
        _dropPowerManager = GetComponent<DropPowerManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKey( KeyCode.UpArrow ) && transform.position.y < -90)
        {
            transform.position = 
                new Vector3(transform.position.x, transform.position.y + movementSpeed, transform.position.z);
        }
        else if( Input.GetKey( KeyCode.Space) && transform.position.y > -230)
        {
            transform.position =
                new Vector3(transform.position.x, transform.position.y - 30, transform.position.z);
            _dropPowerManager.UsePowerUp();
        }
	}
}
