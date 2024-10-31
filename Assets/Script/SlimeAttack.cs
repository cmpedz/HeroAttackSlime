using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : ObjectAttackController
{
    [SerializeField] private float timeWattingForNextAttack;

    private float timeRun;

    new void Start()
    {
        base.Start();

        timeRun = Time.time - timeWattingForNextAttack;    

    }
    public override void AttackEnenmy()
    {
        ObjectHealthController player = DetectEnemy();

        Debug.Log("slime detect player : " + player);

        if (player != null && Time.time - timeRun >= timeWattingForNextAttack && !isAttacking) {

            ActiveAttackStatus();

            timeRun = Time.time;
        }

        CauseDamOnEnemy(player, 0.5f);
    }


}
