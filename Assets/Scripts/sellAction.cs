using UnityEngine;
using System.Collections;

public class sellAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		((Behaviour)this.gameObject.GetComponent("Halo")).enabled = true;
	}

	void OnMouseExit() {
		((Behaviour)this.gameObject.GetComponent("Halo")).enabled = false;
	}

	void OnMouseDown() {
		Debug.LogWarning ("sell the tower and return some 'money'!");
	}
}
