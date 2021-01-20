using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<GameObject> gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnPoint = GameObject.Find("SpawnPoint");

        StartCoroutine(GenerateGameObject(spawnPoint));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateGameObject(GameObject spawnPoint) {
        WaitForSeconds waitTime = new WaitForSeconds(1.5f);
        while (true) {
            if (gameObjects != null && gameObjects.Count > 0) {
                SpriteRenderer spriteRenderer = spawnPoint.GetComponent<SpriteRenderer>();
                float randomSpawnPointX = Random.Range(spriteRenderer.bounds.min.x / 1.5f, spriteRenderer.bounds.max.x / 1.5f);
                float randomSpawnPointY = Random.Range(spriteRenderer.bounds.min.y, spriteRenderer.bounds.max.y);
                Vector3 spawnPointPosition = new Vector3(randomSpawnPointX, randomSpawnPointY, spawnPoint.transform.position.z);

                int randomIndex = Random.Range(0, gameObjects.Count);
                gameObjects[randomIndex].transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
                GameObject randomEnemyGameObject = Instantiate(gameObjects[randomIndex], spawnPointPosition, gameObjects[randomIndex].transform.rotation);
                Destroy(randomEnemyGameObject, 3f);

                yield return waitTime;
            }
        }
    }
}
