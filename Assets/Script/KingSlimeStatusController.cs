using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class KingSlimeStatusController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isAngry = false;

    public bool IsAngry { get { return isAngry; } }

    [SerializeField] private Slider healthBar;

    [SerializeField] private RuntimeAnimatorController angryAnimator;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAngry) {
            bool isHealthLowerThanHalf = healthBar.value < healthBar.maxValue / 2;

            if (isHealthLowerThanHalf)
            {
                isAngry = true;

                GetComponent<Animator>().runtimeAnimatorController = angryAnimator;
            }
        }
        
    }
}
