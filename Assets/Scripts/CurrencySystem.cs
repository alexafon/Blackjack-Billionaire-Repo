using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public int startingBalance = 1000;
    private int currentBalance;

    void Start()
    {
        currentBalance = startingBalance;
        UpdateBalanceUI();
    }

    public void AddAmount(int amount)
    {
        amount = 100;
        currentBalance += amount;
        UpdateBalanceUI();
    }

    public bool SubtractCurrentBetBalance(int amount)
    {
        if (currentBalance >= amount)
        {
            currentBalance -= amount;
            UpdateBalanceUI();
            return true;
        }
        else
        {
            return false;
        }

    }
    public int GetCurrentBalance() 
    {
        return currentBalance;
    }

    public void UpdateBalanceUI()
    {

    }


}
