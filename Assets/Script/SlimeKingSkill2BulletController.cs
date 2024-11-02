using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeKingSkill2BulletController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    [SerializeField] private List<ParticleSystem.Particle> particles;

    [SerializeField] private LayerMask target;

    [SerializeField] private float particleRadius;

    [SerializeField] private float damCause = 2;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        particles = new List<ParticleSystem.Particle>();
    }

    void OnParticleTrigger()
    {
        
        particles.Clear();

        int numInside = particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, particles);

        Debug.Log("check particle system quantity : " +  numInside);


        for (int i = 0; i< numInside; i++)
        {

            Collider2D player = Physics2D.OverlapCircle(particles[i].position, particleRadius, target);

            Debug.Log("check particles position : " + particles[i].position);

            if (player != null) {
                Debug.Log(particles[i].ToString() + " interact with player ");
                player.GetComponent<HeroHealthController>().ReceiveDamFromEnemy(damCause);
            }

           
        }
        
    }
}
