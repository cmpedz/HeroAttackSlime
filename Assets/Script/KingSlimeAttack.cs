using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KingSlimeAttack : ObjectAttackController
{
    [SerializeField] private KingSlimeMovement kingSlimeMovement;

    public override void AttackEnenmy()
    {
        ObjectHealthController player = this.DetectEnemy();

        if (kingSlimeMovement.IsAir) {

            CauseDamOnEnemy(player, 0);

        }
        
    }

}
