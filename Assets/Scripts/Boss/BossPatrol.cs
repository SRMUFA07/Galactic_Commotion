using UnityEngine;

public class BossPatrol : MonoBehaviour 
{
	public Player _player;

	public float bossSpeed;
	public float bossHealth;

	public Transform[] moveSpots;
	private int _randomSpot;

	public GameObject _laserHitParticle;

	public Animator _cameraShake;
	public AudioSource _explosion;
	public GameObject _goldCoin;

    private void Reset()
    {
		moveSpots = GetComponentsInChildren<Transform>();
    }

    private void Start () 
	{
		_randomSpot = Random.Range(0, moveSpots.Length);
	}

	private void Update () 
	{
		BossMove();
		BossDie();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_laserHitParticle, transform.position, Quaternion.identity);
            bossHealth--;
        }
    }

    private void BossMove()
	{
		transform.position = Vector3.MoveTowards(transform.position, moveSpots[_randomSpot].position, bossSpeed * Time.deltaTime);

		var targetOffset = moveSpots[_randomSpot].position - transform.position;

		var playerOffset =  _player.transform.position - transform.position;

		var targetLookAngle = Mathf.Atan2(targetOffset.y, targetOffset.x) * Mathf.Rad2Deg - 90;

		var playerLookAngle = Mathf.Atan2(playerOffset.y, playerOffset.x) * Mathf.Rad2Deg - 90;

		var merageLookAngle = Mathf.LerpAngle(targetLookAngle, playerLookAngle, 0.7f);

		var currentLookAngle = transform.rotation.eulerAngles.z;

		var lerpLookAngle = Mathf.MoveTowardsAngle(currentLookAngle, merageLookAngle, Time.deltaTime * 120);

		transform.rotation = Quaternion.Euler(new Vector3(0, 0, lerpLookAngle));

		if (Vector2.Distance(transform.position, moveSpots[_randomSpot].position) < 1.5f)
			_randomSpot = Random.Range(0, moveSpots.Length);
	}

	private void BossDie()
	{
		if (bossHealth <= 0)
		{
			_explosion.Play();
			gameObject.SetActive(false);
            _cameraShake.SetTrigger("shake");
			Instantiate(_goldCoin, transform.position, Quaternion.identity);
		}
	}
}