using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] _powerups;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _powerupContainer;
    private bool _stopSpawning = false;

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning == false)
        {
            float randomX = Random.Range(-7.7f, 7.7f);
            Vector3 posToSpawn = new Vector3(randomX, 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning == false)
        {
            float randomFreq = Random.Range(3.0f, 8.0f);
            float randomX = Random.Range(-7.7f, 7.7f);
            Vector3 posToSpawn = new Vector3(randomX, 7, 0);
            int randomPowerup = Random.Range(0, 4);
            GameObject newPowerup = Instantiate(_powerups[randomPowerup], posToSpawn, Quaternion.identity);
            newPowerup.transform.parent = _powerupContainer.transform;
            yield return new WaitForSeconds(randomFreq);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}