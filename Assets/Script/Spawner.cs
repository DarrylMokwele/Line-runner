using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnTime;
    Vector3 spawnPos;
    void Start()
    {
        spawnPos = transform.position;
        StartCoroutine(SpawnObstacleRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {

            SpawnObstacle();
            yield return new WaitForSeconds(spawnTime);
            if (spawnTime >= 0.555f)
            {
                 spawnTime -= 0.01f;
            }
           
            
        }
    }


    void SpawnObstacle()
    {
        int randObj = Random.Range(0, obstacles.Length);

        int randomSpot = Random.Range(0, 2);
        
        spawnPos = transform.position;
        if (randomSpot < 1)
        {
            Instantiate(obstacles[randObj], spawnPos, transform.rotation);
        }
        else
        {
            spawnPos = new Vector3(transform.position.x, -transform.position.y, transform.position.z);

            spawnPos.y = -transform.position.y;

            if (randObj == 1)
            {
                spawnPos.x += 1;
            }
            else if (randObj == 2)
            {
                spawnPos.x += 2;
            }
            GameObject obs = Instantiate(obstacles[randObj], spawnPos, transform.rotation);
            obs.transform.eulerAngles = new Vector3(0, 0, 180);
        }

        
        
     
    }
}
