using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealthController : ObjectHealthController
{
    [SerializeField] private GameObject loseMenu;
    public override void ActiveEventWhenObjectDied()
    {
        if (loseMenu != null) {
            Time.timeScale = 0;
            loseMenu.SetActive(true);
        }
    }

}
