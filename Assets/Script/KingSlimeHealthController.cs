using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeHealthController : ObjectHealthController
{

    [SerializeField] private ParticleSystem diedEffect;

    [SerializeField] private float timeDelay;

    [SerializeField] private GameObject winMenu;

    public override void ActiveEventWhenObjectDied()
    {
        if (diedEffect != null)
        {
            Instantiate(diedEffect, transform.position, Quaternion.identity);

            Invoke("DisplayWinMenu", timeDelay);

        }

        
    }

    public void DisplayWinMenu() {
        if (winMenu != null) { 
            Time.timeScale = 0f;
            winMenu.SetActive(true);
            Destroy(gameObject);
        }
    }

}
