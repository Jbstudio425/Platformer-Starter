using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    [SerializeField] private Collectable collectable = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collector>() == null) return;

        collectable.Collect(other.gameObject);
        Destroy(gameObject);
    }
}
