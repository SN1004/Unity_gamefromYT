using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EnemyReference;

    [SerializeField]
    private Transform leftPosition, rightPosition;

    private GameObject spawnedenemy;
    private int randomindex, randomside;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomindex = Random.Range(0, EnemyReference.Length);
            randomside = Random.Range(0, 2);
            spawnedenemy = Instantiate(EnemyReference[randomindex]);

            if (randomside == 0)
            {
                spawnedenemy.transform.position = leftPosition.position;
                spawnedenemy.GetComponent<EnemyMovement>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedenemy.transform.position = rightPosition.position;
                spawnedenemy.transform.localScale = new Vector3(-1f, 1f, 1f);
                spawnedenemy.GetComponent<EnemyMovement>().speed = -Random.Range(4, 10);
            }
        }// while loop
    }
}
