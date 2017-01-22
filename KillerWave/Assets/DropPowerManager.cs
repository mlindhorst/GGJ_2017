using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerManager : MonoBehaviour {

    public GameObject dropPowerIcon;
    private Stack<GameObject> _currentDropPowerIcon;

    public void AddPowerUp()
    {
        if (_currentDropPowerIcon.Count == 3) return;
        var separation = 20 * _currentDropPowerIcon.Count;
        var position = new Vector2(-285 , 85 - separation);
        var newLife = Instantiate(dropPowerIcon, position, new Quaternion());       
        var renderer = newLife.GetComponent<SpriteRenderer>();
        
        renderer.sortingOrder = 1;
        _currentDropPowerIcon.Push(newLife);
    }

    public void UsePowerUp()
    {
        var lastLife = _currentDropPowerIcon.Pop();
        Destroy(lastLife);
    }

    public void Awake()
    {
        _currentDropPowerIcon = new Stack<GameObject>();
    }

    public bool PowerUpsLeft
    {
        get { return _currentDropPowerIcon.Count > 0; }
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
