using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemy());
    }

    IEnumerator RepeatedlySpawnEnemy()
    {
        while(true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondBetweenSpawn);
        }
     
    }
}
