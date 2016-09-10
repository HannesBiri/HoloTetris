using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Transform target;

	public float speed;

	public Vector3 offset;

	public bool init;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (target == null) {
			DestroyImmediate (this.gameObject);
			return;
		}

	    Vector3 direction = (target.position - transform.position) + offset;
		direction.Normalize();

		transform.Translate(direction * Time.deltaTime * speed);
		if (Vector3.Distance (this.transform.position, target.position + offset) < 0.01F) {
			target.gameObject.GetComponent<HealthSystem> ().Attack ();
			target = null;
			DestroyImmediate (this.gameObject);
		}
	}
}
