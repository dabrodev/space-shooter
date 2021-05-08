using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
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
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            float randomX = Random.Range(-9.5f, 9.5f);
            Instantiate(_enemyPrefab, new Vector3(randomX, 11, 0), Quaternion.identity);
        }
    }
}
