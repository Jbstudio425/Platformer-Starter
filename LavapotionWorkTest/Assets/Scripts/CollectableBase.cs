using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UniqueID))]
public class CollectableBase : MonoBehaviour
{
    [SerializeField] private Collectable collectable = null;
    private SceneDataSet sceneDataSet;
    private UniqueID uniqueID;

    private void Start()
    {
        sceneDataSet = FindObjectOfType<SceneDataSet>();
        uniqueID = GetComponent<UniqueID>();

        if(sceneDataSet.removedObjects.Contains(uniqueID.ID)){
            Destroy(this.gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collector>() == null) return;
        sceneDataSet.removedObjects.Add(uniqueID.ID);
        
        Debug.Log(uniqueID.ID + " removed and added to SceneDataSet");

        collectable.Collect(other.gameObject);
        Destroy(gameObject);
    }
}
