using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ObjectHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider healthBar;

    [SerializeField] private float maxHealth;

    [SerializeField] protected ParticleSystem hurtEffect;

    [SerializeField] private AudioManager audioManager;

    [SerializeField] private AudioClip soundEffect;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        if (healthBar != null) { 

            healthBar.maxValue = maxHealth;

            healthBar.value = maxHealth;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamFromEnemy(float damTaken) { 

           float currentHealth = healthBar.value;

           float healthAfterTakenDam = healthBar.value - damTaken;

           string hurtTrigger = (string)KeyValueAnimatorController.GetValueFromKeyObject(KeyInAnimationStatusDictionary.Hurt);

        if (healthAfterTakenDam > 0)
        {

            healthBar.value = healthAfterTakenDam;

            ActiveHurtEffect();

            animator.SetTrigger(hurtTrigger);
        }
        else {
            ActiveEventWhenObjectDied();
        }

    }

    public void ActiveHurtEffect() {
        if (hurtEffect != null)
        {
            Instantiate(hurtEffect, transform.position, Quaternion.identity);
            if (audioManager != null && soundEffect != null)
            {
                audioManager.PlaySFX(soundEffect);
            }

        }
    }

    public abstract void ActiveEventWhenObjectDied();
}
