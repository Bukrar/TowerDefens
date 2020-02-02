using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text text;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemy());
        text.text = score.ToString();
    }

    IEnumerator RepeatedlySpawnEnemy()
    {
        while (true)
        {
            score++;
            text.text = score.ToString();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform; ;
            yield return new WaitForSeconds(secondBetweenSpawn);
        }

    }
}
