using UnityEngine;
using UnityEngine.SceneManagement;

public class ManateeHit : MonoBehaviour {
    private LifeManager _lifeManager;
    private DropPowerManager _dropPowerManager;
    public AudioClip PowerUpSound;
    public AudioClip ObstacleSound;
    private AudioSource aSource;

    // Use this for initialization
    void Start () {
        aSource = GetComponent<AudioSource>();
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

        if (coll.gameObject.tag != "Obstacle") return;
        if(coll.gameObject.name == "Baby_Son_PowerUp(Clone)")
        {
            aSource.clip = PowerUpSound;
            aSource.Play();
            _dropPowerManager.AddPowerUp();
            Destroy(coll.gameObject);
            return;
        }
        if (coll.gameObject.name == "Turnip_PowerUp(Clone)")
        {
            aSource.clip = PowerUpSound;
            aSource.Play();
            _lifeManager.AddLife();
            Destroy(coll.gameObject);
            return;
        }
        aSource.clip = ObstacleSound;
        aSource.Play();
        _lifeManager.LoseLife();
        GetComponent<Animator>().Play("ManateeHit");
        if(!_lifeManager.IsAlive)
        {
            SceneManager.LoadScene("Menu");
        }
            
    }
}
