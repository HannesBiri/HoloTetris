using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public int CurrentMoney = 100;
    public float MaxMoney = 300;


    public void EarnMoney()
    {
        
    }
    public void Charge(int ammount)
    {
        if (CurrentMoney >= ammount)
            CurrentMoney -= ammount;
    }

    public bool CanCharge(int ammount)
    {
        if (CurrentMoney >= ammount)
            return true;

        return false;
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
