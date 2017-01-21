using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {
   public List<GameObject> Obstacles;
    bool readyForTomato = true;

	// Use this for initialization
	void Start () {
	}


	IEnumerator WaitForTomato(float timeOutSec)
    {
        
        readyForTomato = false;
        yield return new WaitForSeconds(timeOutSec);
        var randomIndex = Random.Range(0, Obstacles.Count - 1);
        GameObject objectToSummon = Obstacles[randomIndex];
        GameObject newObstacle = Instantiate(objectToSummon, new Vector2(750, Random.RandomRange(-126f, 0)), new Quaternion());
        newObstacle.AddComponent<ObstacleMovement>();
        var renderer = newObstacle.GetComponent<SpriteRenderer>();
        renderer.sortingOrder = 1;
        readyForTomato = true;
    }

	// Update is called once per frame
	void Update () {

        if (readyForTomato)
            StartCoroutine(WaitForTomato(Random.RandomRange(.5f, 5)));


	}
}
