using UnityEngine;
using System.Collections;

public class UpgradeSpeedAction : MonoBehaviour {

	void OnMouseEnter() {
		((Behaviour)this.gameObject.GetComponent("Halo")).enabled = true;
	}

	void OnMouseExit() {
		((Behaviour)this.gameObject.GetComponent("Halo")).enabled = false;
	}

	void OnMouseDown() {
		Debug.LogWarning ("check and trigger speed upgrade!");
	}
}
