using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPCoin : Coin
{
    private void Start()
    {
        Value *= 5f;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().SpeedBoost(2f, 10f);
        other.GetComponent<PlayerController>().UpgradeJump();
        base.OnTriggerEnter(other);
    }
}
