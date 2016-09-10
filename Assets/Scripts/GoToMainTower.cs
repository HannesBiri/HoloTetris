using UnityEngine;
using System.Collections;

public class GoToMainTower : MonoBehaviour {

	public float distanceToBlowUp = 0.1F;

	// Use this for initialization
	void Start () {
		GetComponent<AIPath>().target = GameObject.FindGameObjectWithTag ("MainTower").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (GetComponent<AIPath> ().target.position, this.transform.position) < distanceToBlowUp) {
			//GameObject.FindGameObjectWithTag ("MainTower")
			DestroyImmediate(this.gameObject);
		}
	}
}
