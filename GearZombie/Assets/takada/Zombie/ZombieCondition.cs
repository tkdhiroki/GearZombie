using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Condition
{
    Slow = 0b_0001,
    Fire = 0b_0010,
}

public class ZombieCondition : MonoBehaviour
{
    private Condition zombieCondition = 0b_0000;
    private void Start()
    {
        zombieCondition = zombieCondition | Condition.Slow;
        Debug.Log(zombieCondition);
        zombieCondition = zombieCondition | Condition.Fire;
        Debug.Log(zombieCondition);
        Condition fire = zombieCondition & Condition.Fire;
        if(fire == Condition.Fire)
        {
            Debug.Log("もえている");
        }
        zombieCondition = zombieCondition & ( ~Condition.Slow);
        Debug.Log(zombieCondition);
    }

}
