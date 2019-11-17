using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(UniqueID))]
public class CharacterBase : MonoBehaviour
{
    [SerializeField] private CharacterBrain brain = null;
    
    private SceneDataSet sceneDataSet;
    private UniqueID uniqueID;

    [HideInInspector] public Rigidbody2D rigidbody = null;
    [HideInInspector] public Animator animator = null;

    public Ability ability = null;
    public LayerMask groundLayer = 8;
    public Transform groundCheck = null;
    public Transform ceilingCheck = null;

    void Awake()
    {
        sceneDataSet = FindObjectOfType<SceneDataSet>();
        uniqueID = GetComponent<UniqueID>();

        if(sceneDataSet.removedObjectsSet.Contains(uniqueID.ID)){
            Destroy(this.gameObject);
            return;
        }

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(brain == null){
            Debug.LogWarning("No brain assigned to " + gameObject.name);
            return;
        } 
        
        brain.Think(this);
    }
}
