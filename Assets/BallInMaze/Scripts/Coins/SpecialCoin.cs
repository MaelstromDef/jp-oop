using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class SpecialCoin : Coin
{
    // POLYMORPHISM
    protected override void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().SpeedBoost(2f, 5f);
        base.OnTriggerEnter(other);
    }
}
