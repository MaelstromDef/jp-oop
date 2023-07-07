using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] protected float Value = 1f;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") other.GetComponent<PlayerController>().CollectCoin(Value);
        Destroy(gameObject);
    }
}
