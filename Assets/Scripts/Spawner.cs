using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject ennemyUnit;
	public int intervalSeconds;
	private float time;

	// Use this for initialization
	void Start () {
		time = intervalSeconds;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (GameObject.FindGameObjectWithTag("MainTower") == null)
	        return;


		time += Time.deltaTime;

		if (time < intervalSeconds)
			return;

		time = 0;

		GameObject go = GameObject.Instantiate (ennemyUnit);
		go.transform.position = this.transform.position;
		go.transform.parent = this.transform;
	}
}
