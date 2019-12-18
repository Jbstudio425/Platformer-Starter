using UnityEngine;
using LP.Saving;
using Zenject;

[RequireComponent(typeof(UniqueID))]
public class CollectableBase : MonoBehaviour
{
    [SerializeField] private Collectable collectable = null;
    private ISceneDataSet sceneDataSet;
    private UniqueID uniqueID;

    [Inject]
    public void Setup(ISceneDataSet sceneDataSet)
    {
        this.sceneDataSet = sceneDataSet;
    }

    private void Start()
    {
        uniqueID = GetComponent<UniqueID>();
        if(sceneDataSet.Contains(uniqueID.ID)){
            Destroy(this.gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collector>() == null) return;
        sceneDataSet.Add(uniqueID.ID);
        
        Debug.Log(uniqueID.ID + " removed and added to SceneDataSet");

        collectable.Collect(other.gameObject);
        Destroy(gameObject);
    }
}
