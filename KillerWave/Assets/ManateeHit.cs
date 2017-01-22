using UnityEngine;
using UnityEngine.SceneManagement;

public class ManateeHit : MonoBehaviour {
    private LifeManager _lifeManager;

    // Use this for initialization
    void Start () {
        _lifeManager = GetComponent<LifeManager>();
        _lifeManager.AddLife();
        _lifeManager.AddLife();
        _lifeManager.AddLife();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Obstacle") return;
        _lifeManager.LoseLife();
        GetComponent<Animator>().Play("ManateeHit");
        if(!_lifeManager.IsAlive)
        {
            SceneManager.LoadScene("Menu");
        }
            
    }
}
