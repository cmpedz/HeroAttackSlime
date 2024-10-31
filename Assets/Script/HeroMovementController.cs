using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : ObjectMovementController
{
    
    public override void Run() {

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

        transform.position += vectorMov ;

    }

 
}
