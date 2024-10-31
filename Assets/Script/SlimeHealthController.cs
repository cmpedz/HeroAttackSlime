using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealthController : ObjectHealthController
{
    [SerializeField] private ParticleSystem diedEffect;
    public override void ActiveEventWhenObjectDied()
    {
        if (diedEffect != null) { 
            Instantiate(diedEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public override void ActiveHurtEffect()
    {
        if (hurtEffect != null)
        {
            Instantiate(hurtEffect, transform.position, Quaternion.identity);

        }
    }

}
