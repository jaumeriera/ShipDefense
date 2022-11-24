using Feto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform[] collisionPoints;
    [SerializeField] Transform[] nonCollisionPoints;
    [SerializeField] Transform DestroyZone;

    // TODO move to scriptable
    [SerializeField] float startingWaitTime;
    [Range(0, 1)]
    [SerializeField] float collisionChance;
    /////////


    ObjectPool pool;
    float timeFromLastSpawn;

    private void Awake() {
        pool = GetComponent<ObjectPool>();
    }

    private void Start() {
        timeFromLastSpawn = - startingWaitTime;
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine() {
        while (true) {
            yield return null;
            timeFromLastSpawn += Time.deltaTime;
            if(timeFromLastSpawn > NextSpawnTime()) {
                Spawn();
                timeFromLastSpawn = 0f;
            }
        }
    }

    private float NextSpawnTime() {
        // TODO implement better function
        return 1.2f;
    }

    private void Spawn() {
        int idx = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[idx];
        // must impact or not?
        Transform objectivePoint;
        float percent = Random.Range(0f, 1f);
        if(percent < collisionChance) {
            idx = Random.Range(0, collisionPoints.Length);
            objectivePoint = collisionPoints[idx];
        } else {
            idx = Random.Range(0, nonCollisionPoints.Length);
            objectivePoint = nonCollisionPoints[idx];
        }

        Vector3 direction = spawnPoint.position - objectivePoint.position;
        // init asteroid
        AsteroidMovement asteroid = (AsteroidMovement)pool.GetNext();
        asteroid.transform.position = spawnPoint.transform.position;
        asteroid.Init(direction, DestroyZone.transform.position.z);
        // active asteroid
        asteroid.gameObject.SetActive(true);
    }

}
