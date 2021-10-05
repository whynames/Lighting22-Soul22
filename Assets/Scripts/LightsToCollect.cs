using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsToCollect : MonoBehaviour
{
    ObjectPooler objectpooler;
    float RandomSpawnTime;

    void Start()
    {
        objectpooler = ObjectPooler.Instance;
        StartCoroutine(SpawnRandomly());

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnRandomly()
    {
        Spawn();
        RandomSpawnTime = Random.Range(0.2f, 1.5f);
        yield return new WaitForSeconds(RandomSpawnTime);
        yield return SpawnRandomly();

    }
    void Spawn()
    {
        objectpooler.SpawnFromPool("Light", new Vector3(10, Random.Range(4.7f, -4.7f), 0), Quaternion.identity, this.transform);
    }
}
