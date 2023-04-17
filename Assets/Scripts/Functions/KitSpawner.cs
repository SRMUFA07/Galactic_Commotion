using UnityEngine;

public class KitSpawner : MonoBehaviour
{
    public GameObject[] kits;
    public Transform[] kitsSpawnPoints;

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
        KitSpawn();
    }

    private void KitSpawn()
    {
        if (_delayBetweenSpawns <= 0)
        {
            _random = Random.Range(0, kits.Length);
            _randomPosition = Random.Range(0, kitsSpawnPoints.Length);

            Instantiate(kits[_random], kitsSpawnPoints[_randomPosition].transform.position, Quaternion.identity);
            _delayBetweenSpawns = startDelayBetweenSpawns;
        }
        else
            _delayBetweenSpawns -= Time.deltaTime;
    }
}
