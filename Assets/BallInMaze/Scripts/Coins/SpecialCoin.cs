using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCoin : Coin
{
    protected override void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().SpeedBoost(2f, 5f);
        base.OnTriggerEnter(other);
    }
}
