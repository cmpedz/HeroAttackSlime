using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeHealthController : ObjectHealthController
{

    [SerializeField] private ParticleSystem diedEffect;
    public override void ActiveEventWhenObjectDied()
    {
        if (diedEffect != null)
        {
            Instantiate(diedEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        
    }

}
