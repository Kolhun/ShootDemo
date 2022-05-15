using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    
    [HideInInspector] public Animator animator;
    [HideInInspector] public new Animation animation;
    private Entity entity;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        entity = GetComponentInParent<Entity>();
    }
    public void OnDieEnd()
    {
        
        entity.controller.OnDieEnd();

    }
}
