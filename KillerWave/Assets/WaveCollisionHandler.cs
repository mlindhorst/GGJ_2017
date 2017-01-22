using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollisionHandler : MonoBehaviour {
    public GameObject SplashObject;
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
        if (collision.gameObject.GetComponent<ObstacleMovement>().HasBeenHit) return;

        if (collision.gameObject.tag != "Obstacle") return;
        transform.position = new Vector2(transform.position.x, transform.position.y - collision.gameObject.transform.lossyScale.y);
        collision.gameObject.GetComponent<ObstacleMovement>().HasBeenHit = true;
        Vector2 spashPosition = new Vector2(collision.transform.position.x - collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2, collision.transform.position.y);
        var splashObject = Instantiate(SplashObject, spashPosition, new Quaternion()); 
        Destroy(splashObject, splashObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
