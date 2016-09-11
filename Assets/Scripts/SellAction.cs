using UnityEngine;
using System.Collections;

public class SellAction : MonoBehaviour {

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
