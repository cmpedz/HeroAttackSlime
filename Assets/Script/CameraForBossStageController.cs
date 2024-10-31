using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForBossStageController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform endPoint;

    [SerializeField] private float speedMove;

    [SerializeField] private Transform currentPoint;

    [SerializeField] private float maxTimeWatting;

    [SerializeField] private Object[] objectsNeedFrozen;

    private float timeRun;

    void Start()
    {
        objectsNeedFrozen = FindObjectsOfType(typeof(ObjectActivitiesController));

        foreach (IObjectActivitiesController _object in objectsNeedFrozen)
        {
            _object.DeActiveActivities();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (currentPoint.position.x <= endPoint.position.x)
        {
            transform.Translate(Vector2.right * speedMove * Time.fixedDeltaTime);
            timeRun = Time.time;
        }
        else {

            if (Time.time - timeRun >= maxTimeWatting) {
                gameObject.SetActive(false);

                foreach (IObjectActivitiesController _object in objectsNeedFrozen)
                {
                    _object.ActiveActivities();
                }
            }
        }
        
    }
}
