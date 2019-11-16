using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterBase : MonoBehaviour
{
    [SerializeField] private CharacterBrain brain = null;

    [HideInInspector] public Rigidbody2D rigidbody = null;
    [HideInInspector] public Animator animator = null;

    public Ability ability = null;
    public LayerMask groundLayer = 8;
    public Transform groundCheck = null;
    public Transform ceilingCheck = null;

    void Awake()
    {
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
