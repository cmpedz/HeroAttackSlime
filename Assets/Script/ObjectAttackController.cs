using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAttackController : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;

    [SerializeField] private float attackRange;

    [SerializeField] private LayerMask target;

    protected Animator animator;

    [SerializeField] protected float dam;

    protected bool isAttacking = false;

    protected void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        AttackEnenmy();
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null) {
            Gizmos.DrawWireSphere(this.attackPoint.position, attackRange);
        }
    }

    public abstract void AttackEnenmy();

    public void CauseDamOnEnemy(ObjectHealthController enemy, float timeGetDam) {



        if (enemy == null) {
            isAttacking = false;
            return;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= timeGetDam && isAttacking)
        {
            enemy.ReceiveDamFromEnemy(this.dam);

            Debug.Log(enemy.ToString() + " received dam");

            isAttacking = false;
        }
    }

    public void ActiveAttackStatus() {

        string attackTrigger = (string)KeyValueAnimatorController.GetValueFromKeyObject(KeyInAnimationStatusDictionary.Attack);

        this.animator.SetTrigger(attackTrigger);

        isAttacking = true;
    }
    

    public ObjectHealthController DetectEnemy() {

        Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, attackRange, target);

        if (enemy != null) { 
            return enemy.GetComponent<ObjectHealthController>();
        }

        return null;
    }
}
