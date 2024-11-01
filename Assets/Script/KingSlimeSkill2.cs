using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KingSlimeSkill2 : ObjectSkill
{
    // Start is called before the first frame update
    [SerializeField] private KingSlimeStatusController kingSlimeStatusController;

    [SerializeField] private ParticleSystem bulletsEffect;

    private bool isCapableUsingSkill2 = false;

    private Animator animator;

    protected new void Start() { 

        base.Start();

        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (isCapableUsingSkill2) {

            float timeAttack = 0.99f;

            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > timeAttack && bulletsEffect != null) {

                Instantiate(bulletsEffect, transform.position, Quaternion.identity);

                isCapableUsingSkill2 = false;

                string specialAttackTrigger = (string)KeyValueAnimatorController.GetValueFromKeyObject(KeyInAnimationStatusDictionary.SpecialAttack);

                animator.SetTrigger(specialAttackTrigger);
            }

        }
    }


    protected override void ConstructSkill()
    {
        if (kingSlimeStatusController != null) {

            if (kingSlimeStatusController.IsAngry) { 
                isCapableUsingSkill2 = true;
            }
        }
    }
}
