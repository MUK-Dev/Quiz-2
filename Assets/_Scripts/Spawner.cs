using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTimerMax = 3f;
    [SerializeField] private GameObject enemyPrefab;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTimerMax)
        {
            spawnTimer = 0f;
            Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
        }
    }
}
