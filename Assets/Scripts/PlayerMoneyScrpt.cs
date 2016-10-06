using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMoneyScrpt : MonoBehaviour
{
    public Image moneyBar;

    private MoneyManager _moneyManager;

    // Use this for initialization
    void Start ()
    {
        _moneyManager = this.GetComponent<MoneyManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float currentHealth = (float)_moneyManager.CurrentMoney / (float)_moneyManager.MaxMoney;

        if (currentHealth < 0)
            moneyBar.fillAmount = 0;
        else
            moneyBar.fillAmount = currentHealth;
    }
}
