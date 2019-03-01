using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackersPrefabs = null;
    bool canSpawn = true;
    
    IEnumerator Start()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackersPrefabs.Length);
        Attacker chosen = attackersPrefabs[attackerIndex];
        Spawn(chosen);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        var newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }
}
