using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private float firstSpawnDelay = 0f;

    [SerializeField]
    private Player player;

    private Vector3 spawnPoint;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnObject", firstSpawnDelay, spawnRate);

        if (player != null)
        {
            player._OnPlayerDied += StopSpawning;
        }
    }

    private void SpawnObject()
    {
        spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(
            Random.Range(0F, 1F), 1F, transform.position.z));

        Pool.instance.RequestTarget(spawnPoint);
    }

    private void StopSpawning()
    {
        CancelInvoke();
    }
}