using UnityEngine;
using UnityEngine.UI;

public class MeteorEnemy : MonoBehaviour
{
    public int meteorHealth;
    public float meteorSpeed;

    public Animator _cameraShake;
    public Player _player;

    public GameObject _laserHitParticle;

    public GameObject _silverCoin;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        MeteorDie();
        ChasePlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser" || other.gameObject.tag == "BossLaser")
        {
            Destroy(other.gameObject);
            Instantiate(_laserHitParticle, transform.position, Quaternion.identity);
            meteorHealth--;
        }
    }

    private void MeteorDie()
    {
        if (meteorHealth <= 0)
        {
            Destroy(gameObject);
            _cameraShake.SetTrigger("shake");
            Instantiate(_silverCoin, transform.position, Quaternion.identity);
        }
    }

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, meteorSpeed * Time.deltaTime);
    }
}
