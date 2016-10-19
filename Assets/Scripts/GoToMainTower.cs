using UnityEngine;
using System.Collections;

public class GoToMainTower : MonoBehaviour {

	public float distanceToBlowUp = 0.1F;
	private GameObject mainTower;

	// Use this for initialization
	void Start () {
		mainTower = GameObject.FindGameObjectWithTag ("MainTower");
	}
	
	// Update is called once per frame
	void Update () {		
		// Update the mainTower position over the time as its transform moves as the player move the grid.
		GetComponent<AIPath> ().target = mainTower.transform;

		if (Vector3.Distance (GetComponent<AIPath> ().target.position, this.transform.position) < distanceToBlowUp)
		{
		    var health = GetComponent<AIPath>().target.gameObject.GetComponent<HealthSystem>();
            if (health)
                health.Attack ();

			DestroyImmediate(this.gameObject);
		}
	}
}
