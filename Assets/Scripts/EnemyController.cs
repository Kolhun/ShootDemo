using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntityController
{

    public override void Die()
    {
        entity.model.animator.enabled = false;
    }



}
