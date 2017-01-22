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
	}
	public void UpdatePowerBar()
    {
        foreach (var powerBarPart in PowerBarParts)
            powerBarPart.enabled = false;
        if (control.PowerBarAmmount > 19)
        {
            foreach (var powerBarPart in PowerBarParts)
                powerBarPart.enabled = true;
        }
        if (control.PowerBarAmmount > 16 && control.PowerBarAmmount < 20)
        {
            foreach (var powerBarPart in PowerBarParts.GetRange(0, 4))
                powerBarPart.enabled = true;
        }
        if (control.PowerBarAmmount > 12 && control.PowerBarAmmount < 16)
        {
            foreach (var powerBarPart in PowerBarParts.GetRange(0, 3))
                powerBarPart.enabled = true;
        }
        if (control.PowerBarAmmount > 8 && control.PowerBarAmmount < 12)
        {
            foreach (var powerBarPart in PowerBarParts.GetRange(0, 2))
                powerBarPart.enabled = true;
        }
        if (control.PowerBarAmmount > 4 && control.PowerBarAmmount < 8)
        {
            foreach (var powerBarPart in PowerBarParts.GetRange(0, 1))
                powerBarPart.enabled = true;
        }
        if (control.PowerBarAmmount < 4)
        {
            foreach (var powerBarPart in PowerBarParts)
                powerBarPart.enabled = false;
        }
    }
	// Update is called once per frame
	void Update () {
        UpdatePowerBar();
	}
}
