using System.Collections;

using Unity.VisualScripting;
using UnityEngine;

public class HeroAttackController : ObjectAttackController
{

    public override void AttackEnenmy()
    {
        ObjectHealthController enemy = this.DetectEnemy();


        if (Input.GetMouseButtonDown(0) && !isAttackingEnemy) {

            ActiveAttackStatus(enemy);

        }

        CauseDamOnEnemy(enemy, 0.9f);
    }

   


}
