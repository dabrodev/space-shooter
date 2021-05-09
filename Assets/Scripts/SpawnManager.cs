using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // spawn game objects every 5 seconds
    // Create a coroutine of type IEnumerator -- Yield Events
    // while loop

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            float randomX = Random.Range(-9.5f, 9.5f);
            Vector3 posToSpawn = new Vector3(randomX, 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
