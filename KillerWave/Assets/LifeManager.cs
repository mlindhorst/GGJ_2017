using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

    public GameObject LifeIcon;
    private Stack<GameObject> _currentLifeIcons;

    private static int UPPERLEFT_X = -280;
    private static int UPPERLEFT_Y = 162;
    public void AddLife()
    {
        if (_currentLifeIcons.Count == 3) return;
        var separation = 30 * _currentLifeIcons.Count;
        var position = new Vector2(UPPERLEFT_X + separation, UPPERLEFT_Y);
        var newLife = Instantiate(LifeIcon, position, new Quaternion());
        var renderer = newLife.GetComponent<SpriteRenderer>();

        renderer.sortingOrder = 1;
        _currentLifeIcons.Push(newLife);        
    }

    public void LoseLife()
    {
        var lastLife = _currentLifeIcons.Pop();
        Destroy(lastLife);
    }

    public void Awake()
    {
        _currentLifeIcons = new Stack<GameObject>();
    }
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsAlive
    {
        get { return _currentLifeIcons.Count > 0; }
    }
}
