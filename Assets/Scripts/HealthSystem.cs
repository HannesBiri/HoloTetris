using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int currentLife;
	public int maxLife = 100;

	// Use this for initialization
	void Start () {
		currentLife = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Attack()
	{
		Debug.Log (name + "got hitted");
		currentLife -= 20;

		if (currentLife < 1)
			DestroyImmediate (this.gameObject);
	}
}
