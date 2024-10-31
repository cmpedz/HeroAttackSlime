using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlimeMovement : ObjectMovementController
{
    [SerializeField] private Transform visionPoint;

    [SerializeField] private float visisionRange;

    [SerializeField] private LayerMask target;

    [SerializeField] private SlimeAttack slimeAttack;


    public override void Run()
    {
        Collider2D player = Physics2D.OverlapCircle(visionPoint.position, visisionRange, target);

        bool canAttackPlayer = slimeAttack.DetectEnemy() != null;

        if (player != null && !canAttackPlayer) { 

            float direction = Mathf.Sign(player.transform.position.x - transform.position.x);

            Debug.Log("check direction : " + direction);

            Flip(direction);

            transform.position += new Vector3(direction * speedRun * Time.fixedDeltaTime, 0, 0);
        }   
    }

    private void OnDrawGizmos()
    {
        if (visionPoint != null)
        {
            Gizmos.DrawWireSphere(this.visionPoint.position, visisionRange);
        }
    }

}
