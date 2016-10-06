using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TuretShoot : MonoBehaviour {

	public GameObject headTurret;
	public GameObject projectile;
	public Transform canon;
	public float range; 

	public float intervalSeconds;
	private float time;

	private Vector3 savedfocuslocation;

	public Transform focusedDude;

	public List<GameObject> ennemies;

    public AudioClip shootSound;

    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
		time = intervalSeconds;
		savedfocuslocation = this.transform.position;
		focusedDude = null;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (focusedDude != null) {
			savedfocuslocation = focusedDude.transform.position;
			RotateToward (focusedDude.transform.position);
		}


		time += Time.deltaTime;

		if (time < intervalSeconds)
			return;

		time = 0;
		ennemies = GameObject.FindGameObjectsWithTag ("Ennemy").ToList ();
		if (focusedDude == null) {
			
			foreach (var ennemy in ennemies) {
				if (Vector3.Distance (this.transform.position, ennemy.transform.position) < range) {
					focusedDude = ennemy.gameObject.transform;
					break;
				}
			}
		}
		if (focusedDude != null) {
			if (Vector3.Distance (this.transform.position, focusedDude.transform.position) > range) {
				focusedDude = null;
				return;
			}


			//Debug.Log ("shoot at " + focusedDude.gameObject.name);

			GameObject go = Instantiate (projectile);
            if (shootSound != null)
                audioSource.PlayOneShot(shootSound);

            go.GetComponent<Projectile> ().target = focusedDude.gameObject.transform;
			go.transform.position = canon.transform.position;

			if (focusedDude.GetComponent<HealthSystem>().currentLife < 1) {
				
				focusedDude = null;
				return;
			}
		}
	}

	void RotateToward(Vector3 targetPos)
    {
        Vector3 directionX = transform.position - targetPos;
       
	    var rotation = Quaternion.LookRotation(directionX, transform.up);
        rotation *= Quaternion.Euler(0, -90, 0); // this add a -90 degrees Y rotation

        headTurret.transform.rotation = Quaternion.Slerp(headTurret.transform.rotation, rotation, 30f);
    }
}
