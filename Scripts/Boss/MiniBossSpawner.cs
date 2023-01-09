using UnityEngine;

public class MiniBossSpawner : MonoBehaviour
{
    public GameObject _miniBoss;

    public float startDelayBetweenSpawns;
    private float _delayBetweenSpawns;

    private void Start()
    {
        _delayBetweenSpawns = startDelayBetweenSpawns;
    }

    private void Update()
    {
        MiniBossSpawn();
    }

    private void MiniBossSpawn()
    {
        if (_delayBetweenSpawns <= 0)
        {
            _miniBoss.SetActive(true);
            _delayBetweenSpawns = startDelayBetweenSpawns;
        }
        else
            _delayBetweenSpawns -= Time.deltaTime;
    }
}
