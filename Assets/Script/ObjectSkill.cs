using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSkill : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float maxTimeWatting;

    private float timeRun;

    protected void Start()
    {
           timeRun = Time.time;
    }

    public void UseSkill() {

        if (Time.time - timeRun >= maxTimeWatting) { 

            timeRun = Time.time;

            ConstructSkill();

        }
    }

    protected abstract void ConstructSkill();

}
