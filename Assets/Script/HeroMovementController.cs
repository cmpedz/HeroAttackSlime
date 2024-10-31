using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : ObjectMovementController
{
    [SerializeField] private  Transform limitLeftPoint;
    public Transform LimitLeftPoint { get { return limitLeftPoint; }  set { limitLeftPoint = value; } }

    [SerializeField] private Transform limitRightPoint;

    public Transform LimitRightPoint { get { return limitRightPoint; } set { limitRightPoint = value; } }

    public override void Move() {

        Vector3 vectorMov = new Vector3(0, 0,0);

        if (Input.GetKey(KeyCode.D)) vectorMov += new Vector3(speedRun * Time.fixedDeltaTime, 0,0);

        if (Input.GetKey(KeyCode.A)) vectorMov += new Vector3(-speedRun * Time.fixedDeltaTime, 0,0);

        if(Input.GetKey(KeyCode.W)) vectorMov += new Vector3(0, jumpForce * Time.fixedDeltaTime, 0);


        if (vectorMov.x != 0) {

            int valueRun = (int)KeyValueAnimatorController.GetValueFromKeyObject(KeyInAnimationStatusDictionary.Run);

            ChangeStatus(valueRun);

            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        Flip(vectorMov.x);

        if (limitLeftPoint != null && limitRightPoint != null) {

            bool isOverCrossLimitation = (transform.position.x + vectorMov.x > limitRightPoint.position.x) || (transform.position.x + vectorMov.x < limitLeftPoint.position.x);

            if (isOverCrossLimitation)
            {

                vectorMov = new Vector3(0, vectorMov.y, vectorMov.z);
            }
        }
        
        transform.position += vectorMov ;

    }

 
}
