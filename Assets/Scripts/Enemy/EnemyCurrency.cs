using UnityEngine;

internal class EnemyCurrency : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int goldReward = 25, goldpenalty = 25;

    //CACHED CLASSES REFERENCES
    Enemy enemy;

    internal void CustomStart()
    {
        enemy = GetComponent<Enemy>();
    }

    internal void RewardGold()
    {
        if (!enemy.bank) { return; }

        enemy.bank.Deposit(goldReward);
    }

    internal void StealGold()
    {
        if (!enemy.bank) { return; }

        enemy.bank.Withdraw(goldpenalty);
    }
}