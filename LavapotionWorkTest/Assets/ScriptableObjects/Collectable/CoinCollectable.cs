using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Collectables/Coin")]
public class CoinCollectable : Collectable
{
    public int points = 1;

    public override void Collect(GameObject collector){
        collector.GetComponent<Collector>().AddPoints(points);
    }
}
