using UnityEngine;
using UnityEngine.SceneManagement;

public class ManateeHit : MonoBehaviour {
    private LifeManager _lifeManager;
    private DropPowerManager _dropPowerManager;

    // Use this for initialization
    void Start () {
        _dropPowerManager = transform.parent.GetComponent<DropPowerManager>();
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
        if(coll.gameObject.name == "Baby_Son_PowerUp(Clone)")
        {            
            _dropPowerManager.AddPowerUp();
            Destroy(coll.gameObject);
            return;
        }
        if (coll.gameObject.name == "Turnip_PowerUp(Clone)")
        {
            _lifeManager.AddLife();
            Destroy(coll.gameObject);
            return;
        }

        _lifeManager.LoseLife();
        GetComponent<Animator>().Play("ManateeHit");
        if(!_lifeManager.IsAlive)
        {
            SceneManager.LoadScene("Menu");
        }
            
    }
}
