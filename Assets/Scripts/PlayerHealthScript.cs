using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    public Image healthBar;

    private HealthSystem _healthSystem;

    // Use this for initialization
    void Start ()
	{
        _healthSystem = this.GetComponent<HealthSystem>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float currentHealth = (float) _healthSystem.currentLife/ (float) _healthSystem.maxLife;

        if (currentHealth < 0)
	        healthBar.fillAmount = 0;
	    else
    	    healthBar.fillAmount = currentHealth;
	}
}
