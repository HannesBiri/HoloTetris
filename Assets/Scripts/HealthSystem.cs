using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int currentLife;
	public int maxLife = 100;
    public GameObject explosionEffect;

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

        if (currentLife <= 1 && gameObject.activeSelf)
        {
            Instantiate(explosionEffect, this.transform.position, this.transform.rotation);
            Debug.Log("explosion");
            this.gameObject.SetActive(false);

            Destroy(this.gameObject, 0.1f);
        }
	}
}
