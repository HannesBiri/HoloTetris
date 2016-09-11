
using UnityEngine;
using System.Collections;

public class CameraAlignment : MonoBehaviour {

	void Update () {
		this.gameObject.transform.parent.transform.LookAt(Camera.main.transform);
		// correction because of the natural rotation of this exact object
		this.gameObject.transform.parent.transform.Rotate (90, 0, 0);
	}
}
