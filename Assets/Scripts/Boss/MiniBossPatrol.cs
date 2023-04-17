using UnityEngine;

public class MiniBossPatrol : MonoBehaviour
{
    public GameObject _player;

    public float miniBossSpeed;
    public float miniBossHealth;

    public Transform[] miniBossMoveSpots;
    private int _randomSpot;

    public GameObject _laserHitParticle;

    public Animator _cameraShake;
    public AudioSource _explosion;
    public GameObject _bronzeCoin;

    private void Reset()
    {
        miniBossMoveSpots = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        _randomSpot = Random.Range(0, miniBossMoveSpots.Length);
    }

    private void Update()
    {
        MiniBossMove();
        MiniBossDie();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_laserHitParticle, transform.position, Quaternion.identity);
            miniBossHealth--;
        }
    }

    private void MiniBossMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, miniBossMoveSpots[_randomSpot].position, miniBossSpeed * Time.deltaTime);

        var targetOffset = miniBossMoveSpots[_randomSpot].position - transform.position;

        var playerOffset = _player.transform.position - transform.position;

        var targetLookAngle = Mathf.Atan2(targetOffset.y, targetOffset.x) * Mathf.Rad2Deg - 90;

        var playerLookAngle = Mathf.Atan2(playerOffset.y, playerOffset.x) * Mathf.Rad2Deg - 90;

        var merageLookAngle = Mathf.LerpAngle(targetLookAngle, playerLookAngle, 0.7f);

        var currentLookAngle = transform.rotation.eulerAngles.z;

        var lerpLookAngle = Mathf.MoveTowardsAngle(currentLookAngle, merageLookAngle, Time.deltaTime * 120);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, lerpLookAngle));

        if (Vector2.Distance(transform.position, miniBossMoveSpots[_randomSpot].position) < 1.5f)
            _randomSpot = Random.Range(0, miniBossMoveSpots.Length);
    }

    private void MiniBossDie()
    {
        if (miniBossHealth <= 0)
        {
            _explosion.Play();
            gameObject.SetActive(false);
            _cameraShake.SetTrigger("shake");
            Instantiate(_bronzeCoin, transform.position, Quaternion.identity);
            miniBossHealth = 15;
        }
    }
}
