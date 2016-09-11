
using UnityEngine;
using System.Collections;

public class alignWithCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.parent.transform.LookAt(Camera.main.transform);
		// correction because of the natural rotation of this exact object
		this.gameObject.transform.parent.transform.Rotate (90, 0, 0);
	}
}
