using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;
    public Enemy[] enemyPrefabList;
    public Transform[] spawnLocations;

    public int maxEnemies = 5;
    public int enemiesToSpawn = 3;
    private int numberSpawned = 0;
    private List<Enemy> enemiesOnField = new List<Enemy>();
    private Transform playerRef;


    private void Awake()
    {
        instance = this;

        playerRef = GameObject.FindAnyObjectByType<PlayerMove>().transform;
    }

    private void Start()
    {
        StartCoroutine(StartWavesAfterDelay(10f));
    }

    public void StartSpawnSequence(int enemiesMax, int numberToSpawn)
    {
        Debug.Log("Spawning Enemies");
        enemiesOnField.Clear();
        maxEnemies = enemiesMax;
        enemiesToSpawn = numberToSpawn;
        numberSpawned = 0;

        StartCoroutine(StartSpawnSequence());
    }

    private IEnumerator StartSpawnSequence()
    {
        yield return null;

        while (numberSpawned < enemiesToSpawn)
        {
            if (enemiesOnField.Count < maxEnemies)
            {
                Transform spawnPoint = GetFurthestSpawnPoint();

                Enemy prefabToSpawn = SelectEnemyToSpawn();

                Enemy spawnedEnemy = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
                enemiesOnField.Add(spawnedEnemy);
                numberSpawned++;
                spawnedEnemy.health.Death += () => OnEnemyDeath(spawnedEnemy);
                NavMeshAgent enemyAgent = spawnedEnemy.GetComponent<NavMeshAgent>();
                enemyAgent.enabled = false;

                yield return new WaitForSeconds(.5f);
                yield return null;
                enemyAgent.enabled = true;
            }

            yield return null;
        }
    }

    private Transform GetFurthestSpawnPoint()
    {
        Transform furthestPoint = spawnLocations[0];
        float furthestDist = Vector3.Distance(spawnLocations[0].position, playerRef.position);

        for (int ind = 1; ind < spawnLocations.Length; ind++)
        {
            float dist = Vector3.Distance(spawnLocations[ind].position, playerRef.position);
            if (dist > furthestDist)
            {
                furthestDist = dist;
                furthestPoint = spawnLocations[ind];
            }
        }

        return furthestPoint;
    }

    private Enemy SelectEnemyToSpawn()
    {
        int index = Random.Range(0, enemyPrefabList.Length);
        return enemyPrefabList[index];
    }

    private void OnEnemyDeath(Enemy deadEnemy)
    {
        enemiesOnField.Remove(deadEnemy);

        if (enemiesOnField.Count == 0)
        {
            enemiesToSpawn++;

            if (enemiesToSpawn >= maxEnemies)
                maxEnemies += 5;

            StartWavesAfterDelay(10f);
        }
    }

    IEnumerator StartWavesAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        StartSpawnSequence(maxEnemies, enemiesToSpawn);
    }

#if UNITY_EDITOR
    [ContextMenu("Start Spawn Sequence")]
    public void MenuStart()
    {
        StartSpawnSequence(5, 3);
    }
#endif
}
