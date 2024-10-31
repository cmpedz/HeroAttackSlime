using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlimeMovement : ObjectMovementController
{
    [SerializeField] private ObjectVisionController vision;

    [SerializeField] private SlimeAttack slimeAttack;


    public override void Move()
    {
        Collider2D player = vision.GetEnemy();

        bool canAttackPlayer = slimeAttack.DetectEnemy() != null;

        if (player != null && !canAttackPlayer) { 

            float direction = Mathf.Sign(player.transform.position.x - transform.position.x);

            Debug.Log("check direction : " + direction);

            Flip(direction);

            transform.position += new Vector3(direction * speedRun * Time.fixedDeltaTime, 0, 0);
        }   
    }

    

}
