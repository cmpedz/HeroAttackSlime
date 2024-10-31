using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisionController : MonoBehaviour
{

    [SerializeField] private Transform visionPoint;

    [SerializeField] private float visisionRange;

    [SerializeField] private LayerMask target;

    public Collider2D GetEnemy() { 
        return Physics2D.OverlapCircle(visionPoint.position, visisionRange, target);
    }

    private void OnDrawGizmos()
    {
        if (visionPoint != null)
        {
            Gizmos.DrawWireSphere(this.visionPoint.position, visisionRange);
        }
    }
}
