using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public int MinionCount;
    public float spawnrate = 8.5f;
    public int minionmax = 10;

    public GameObject minion;
    public Transform[] spawn;
  
    
    private void Start()
    {
        int i = 0;
        foreach (Transform spawns in transform)
        {
            spawn[i] = spawns;
            i++;
        }
        StartCoroutine(SpawnStart());
    }


    IEnumerator SpawnStart()
    {
        while (true)
        {
            while (MinionCount < minionmax)
            {
                int Rand = Random.Range(0, spawn.Length);
                Instantiate(minion, spawn[Rand].position,minion.transform.rotation);
                yield return new WaitForSeconds(spawnrate);
            }
        }

    }
}
