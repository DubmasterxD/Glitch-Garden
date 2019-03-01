using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathParticles = null;
    [SerializeField] Transform deathParticleSpawnPoint = null;

    public void DealDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if(!deathParticles)
        {
            return;
        }
        GameObject deathVFX = Instantiate(deathParticles, deathParticleSpawnPoint.position, deathParticles.transform.rotation);
        Destroy(deathVFX, 0.5f);
    }
}
