using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] meteorEnemy;
    public Transform[] spawnPoint;

    private int _random;
    private int _randomPosition;

    public float startDelayBetweenSpawns;
    private float _delayBetweenSpawns;

    private void Start()
    {
        _delayBetweenSpawns = startDelayBetweenSpawns;
    }

    private void Update() 
    {
        MeteorSpawn();
    }

    private void MeteorSpawn()
    {
        if (_delayBetweenSpawns <= 0)
        {
            _random = Random.Range(0, meteorEnemy.Length);
            _randomPosition = Random.Range(0, spawnPoint.Length);

            Instantiate(meteorEnemy[_random], spawnPoint[_randomPosition].transform.position, Quaternion.identity);
            _delayBetweenSpawns = startDelayBetweenSpawns;
        }
        else
            _delayBetweenSpawns -= Time.deltaTime;
    }
}
