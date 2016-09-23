using UnityEngine;
using System.Collections;

public class attractedByHuman : MonoBehaviour
{
	private Transform human;
	public float force =  30;
	// Use this for initialization
	void Start ()
	{
		human = FindObjectOfType<Camera>().gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = (human.position - transform.position);
		direction.Normalize() ;

         GetComponent<Rigidbody>().AddForce(direction * force * Time.deltaTime);

	}
}
