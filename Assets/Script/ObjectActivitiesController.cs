using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivitiesController : MonoBehaviour,IObjectActivitiesController
{

    [SerializeField] private List<MonoBehaviour> activities = new List<MonoBehaviour>();
    public void ActiveActivities()
    {
        
        foreach (MonoBehaviour activity in activities) { 
            activity.enabled = true;
        }
    }

    public void DeActiveActivities()
    {
        foreach (MonoBehaviour activity in activities)
        {
            activity.enabled = false;
        }
    }
}
