using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2SpawnerController : MonoBehaviour
{
 [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnRate = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyWave());
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab) as GameObject;
        int side = Random.Range(0,4);
        switch (side)
        {
            //left
            case 0:
            {
            Vector2 vec = Camera.main.ScreenToWorldPoint(new Vector2(0, Random.Range(0,Screen.height)));
            enemyInstance.transform.position = new Vector2(vec.x, vec.y);
            //enemyInstance.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0, Random.Range(0,Screen.height)));
            break;
            }

            //down
            case 1:
            {
            Vector2 vec = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0,Screen.width),0));
            enemyInstance.transform.position = new Vector2(vec.x, vec.y);
            //enemyInstance.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0,Screen.width),0));
            break;
            }

            //right
            case 2:
            {
            Vector2 vec = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Random.Range(0,Screen.height)));
            enemyInstance.transform.position = new Vector2(vec.x, vec.y);
            break;
            }
            //enemyInstance.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Random.Range(0,Screen.height)));           
            //break;

            //top
            case 3:
            {
            Vector2 vec = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0,Screen.width),Screen.height));
            enemyInstance.transform.position = new Vector2(vec.x, vec.y);
            break;
            }
            //enemyInstance.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0,Screen.width),Screen.height));         
            //break;
        }
        //enemyInstance.transform.position = new Vector2(0,0);
        //enemyInstance.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(0, Random.Range(0,Screen.height))).x,Camera.main.ScreenToWorldPoint(new Vector2(0, Random.Range(0,Screen.height))).y);
        //Vector2 vec = Camera.main.ScreenToWorldPoint(new Vector2(0, Random.Range(0,Screen.height)));
        //enemyInstance.transform.position = vec;
    }

    private IEnumerator EnemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy();

        }
    }
}
