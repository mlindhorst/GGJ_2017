using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollisionHandler : MonoBehaviour {
    private PolygonCollider2D _collider;
    private GameObject _wave;
    // Use this for initialization
    void Start () {
        _collider = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
    
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - collision.gameObject.transform.lossyScale.y);
        Destroy(collision.gameObject.GetComponent<Collider2D>());
    }
}
