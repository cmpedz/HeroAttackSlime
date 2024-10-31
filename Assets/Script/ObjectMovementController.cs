using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float speedRun;

    [SerializeField] protected float jumpForce;

    protected bool isFlip = false;

    protected bool isRunning = false;
    

    protected Animator animator;
    protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected void Update()
    {
        ActiveIdleStatus();

    }


    private void FixedUpdate()
    {
        Move();
    }

    public abstract void Move();

    private void ActiveIdleStatus()
    {

        int valueIdle = (int)KeyValueAnimatorController.GetValueFromKeyObject(KeyInAnimationStatusDictionary.Idle);

        string keyIdle = (string)KeyValueAnimatorController.GetValueFromKeyObject(KeyInAnimationStatusDictionary.ChangeMove);

        if (!isRunning && animator.GetInteger(keyIdle) != valueIdle)
        {
            animator.SetInteger(keyIdle, valueIdle);
        }
    }

    public void ChangeStatus(int status)
    {

        string keyRun = (string)KeyValueAnimatorController.GetValueFromKeyObject(KeyInAnimationStatusDictionary.ChangeMove);

        animator.SetInteger(keyRun, status);

    }




    public void Flip(float direction)
    {
        if (direction < 0 && !isFlip)
        {
            FlipObject();
        }

        if (direction > 0 && isFlip)
        {
            FlipObject();
        }
    }

    private void FlipObject()
    {
        isFlip = !isFlip;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

}
