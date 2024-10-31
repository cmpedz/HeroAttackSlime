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

    protected bool isAttackingEnemy = false;
    public bool IsAttackingEnemy { get { return isAttackingEnemy; } set { isAttackingEnemy = value; } }

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

    public bool CauseDamOnEnemy(ObjectHealthController enemy, float timeGetDam) {


        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= timeGetDam && isAttackingEnemy && enemy != null)
        {
            enemy.ReceiveDamFromEnemy(this.dam);

            Debug.Log(enemy.ToString() + " received dam");

            isAttackingEnemy = false;

            return true;
        }

        return false;
    }

    public void ActiveAttackStatus(ObjectHealthController enemy) {

        string attackTrigger = (string)KeyValueAnimatorController.GetValueFromKeyObject(KeyInAnimationStatusDictionary.Attack);

        this.animator.SetTrigger(attackTrigger);

        if (enemy != null) {
            isAttackingEnemy = true;
        }
        
    }
    

    public ObjectHealthController DetectEnemy() {

        Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, attackRange, target);

        if (enemy != null) { 
            return enemy.GetComponent<ObjectHealthController>();
        }

        return null;
    }
}
