using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour {

    public float PowerBarAmmount = 24;
    public float movementSpeed;
    private DropPowerManager _dropPowerManager;
    public static UserControl instance;
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        _dropPowerManager = GetComponent<DropPowerManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
		if( Input.GetKey( KeyCode.UpArrow ) && transform.position.y < -90 && PowerBarAmmount > 0)
        {
            PowerBarAmmount = PowerBarAmmount - .5f; ;
            transform.position = 
                new Vector3(transform.position.x, transform.position.y + movementSpeed, transform.position.z);
        }
        else if( Input.GetKey( KeyCode.Space) && transform.position.y > -230)
        {
            transform.position =
                new Vector3(transform.position.x, transform.position.y - 30, transform.position.z);
            _dropPowerManager.UsePowerUp();
        }
        if (PowerBarAmmount < 24 && !Input.GetKey(KeyCode.UpArrow))
        {
            PowerBarAmmount += .2f;
        }
    }
}
