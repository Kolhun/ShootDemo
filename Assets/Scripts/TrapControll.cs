using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrapControll : EntityController
{
    public Collider trigger;

    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            
            entity.model.animation.Play();
            other.GetComponent<Entity>().Kill();

        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    

}
