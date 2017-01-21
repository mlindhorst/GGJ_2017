using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerBarController : MonoBehaviour {
    private List<SpriteRenderer> PowerBarParts { get; set; }
    private UserControl control;
	// Use this for initialization
	void Start () {

        PowerBarParts = GetComponentsInChildren<SpriteRenderer>().ToList();
        control = GameObject.Find("Wave").GetComponent<UserControl>();
        control.UpdateBar += UpdatePowerBar;
	}
	public void UpdatePowerBar()
    {
        foreach (var powerBarPart in PowerBarParts)
            powerBarPart.enabled = false;

        if (control.PowerBarAmmount == 20)
        {
            foreach (var powerBarPart in PowerBarParts)
                powerBarPart.enabled = true;
        }
        if (control.PowerBarAmmount > 15 && control.PowerBarAmmount < 20)
        {
            foreach (var powerBarPart in PowerBarParts.GetRange(0, 4))
                powerBarPart.enabled = true;
        }
        if (control.PowerBarAmmount > 10 && control.PowerBarAmmount < 15)
        {
            foreach (var powerBarPart in PowerBarParts.GetRange(0, 3))
                powerBarPart.enabled = true;
        }
        if (control.PowerBarAmmount > 5 && control.PowerBarAmmount < 10)
        {
            foreach (var powerBarPart in PowerBarParts.GetRange(0, 2))
                powerBarPart.enabled = true;
        }
        if (control.PowerBarAmmount < 5)
        {
            foreach (var powerBarPart in PowerBarParts.GetRange(0, 1))
                powerBarPart.enabled = true;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
