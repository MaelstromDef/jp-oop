using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class OPCoin : Coin
{
    private void Start()
    {
        Value *= 5f;
    }

    // POLYMORPHISM
    protected override void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().SpeedBoost(2f, 10f);
        other.GetComponent<PlayerController>().UpgradeJump();
        base.OnTriggerEnter(other);
    }
}
