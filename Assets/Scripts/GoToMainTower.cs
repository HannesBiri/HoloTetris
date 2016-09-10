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
		if (Vector3.Distance (GetComponent<AIPath> ().target.position, this.transform.position) < distanceToBlowUp)
		{
		    var health = GetComponent<AIPath>().target.gameObject.GetComponent<HealthSystem>();
            if (health)
                health.Attack ();

			DestroyImmediate(this.gameObject);
		}
	}
}
