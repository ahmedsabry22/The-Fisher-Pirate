using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefabs;
    public Transform[] fishSpawnPoints;
    public Transform[] fishTargetPoints;

    private void Start()
    {
        StartCoroutine(SpawnFish());
    }

    private IEnumerator SpawnFish()
    {
        while (true)
        {
            yield return (new WaitForSeconds(Random.Range(1, 2.5f)));

            int fishIndex = Random.Range(0, fishPrefabs.Length);
            int spawnPointIndex = Random.Range(0, fishSpawnPoints.Length);

            GameObject fish = Instantiate(fishPrefabs[fishIndex], fishSpawnPoints[spawnPointIndex].position, Quaternion.identity);

            fish.GetComponent<FishMovement>().Target = fishTargetPoints[spawnPointIndex];
        }
    }
}