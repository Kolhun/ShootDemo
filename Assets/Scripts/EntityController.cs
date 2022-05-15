using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    
    [HideInInspector] public Entity entity;

    public virtual void Awake()
    {
        entity = GetComponent<Entity>();
    }
    public virtual void Die()
    {

    }
    public virtual void OnDieEnd()
    {

        

    }

    public virtual void OnPathEnd()
	{

	}

}
