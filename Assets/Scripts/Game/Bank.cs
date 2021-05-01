using UnityEngine;

public class Bank : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int startBalance = 150;

    //STATE
    private int currentBalance;

    //EXTERNAL CLASSES REFERENCES
    GoldDisplay goldDisplay;

    //PROPERTIES
    public int CurrentBalance { get { return currentBalance; } }

    private void Start()
    {
        goldDisplay = FindObjectOfType<GoldDisplay>();
        currentBalance = startBalance;
        UpdateBalanceDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBalanceDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateBalanceDisplay();

        if(currentBalance < 0)
        {
            Debug.Log("You lost!");
            FindObjectOfType<SceneLoader>().DeathRestart();
        }
    }

    private void UpdateBalanceDisplay()
    {
        goldDisplay.UpdateDisplay(currentBalance);
    }
}
