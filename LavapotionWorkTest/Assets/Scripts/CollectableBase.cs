using UnityEngine;
using LP.Saving;
using Zenject;

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

        if(sceneDataSet.removedObjectsSet.Contains(uniqueID.ID)){
            Destroy(this.gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collector>() == null) return;
        sceneDataSet.removedObjectsSet.Add(uniqueID.ID);
        
        Debug.Log(uniqueID.ID + " removed and added to SceneDataSet");

        collectable.Collect(other.gameObject);
        Destroy(gameObject);
    }
}
