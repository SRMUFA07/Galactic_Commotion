using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSistem : MonoBehaviour
{
    public GameObject _gameOverPanel;
    public Text _hpValueCanvas;

    public float healthKitRecovery;
    public float playerHealth;

    public GameObject _playerShield;
    public Shield _shieldTimer;

    public GameObject _enemyHitParticle;
    public float meteorDamage;
    public float bossLaserDamage;

    public GameObject _bossSummonPanel;
    public BossPatrol _bossScript;
    public GameObject _boss;
    public bool bossSummonFirstTime = false;
    public bool bossSummonSecondTime = false;
    public bool bossSummonThirdTime = false;
    public bool bossSummonFourTime = false;
    public bool bossSummonFiveTime = false;
    public bool bossSummonSixTime = false;
    public bool bossSummonSevenTime = false;

    private void Start() 
    {
        _hpValueCanvas.text = "HP: " + playerHealth.ToString();
    }

    private void Update() 
    {
        PlayerDie();
        BossSummon();

        if (_playerShield.activeInHierarchy)
            bossLaserDamage = 0;
        else
            bossLaserDamage = 1;
    }

    private void PlayerDie()
    {
        if (playerHealth <= 0)
        {
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Meteor")
        {
            Instantiate(_enemyHitParticle, transform.position, Quaternion.identity);
            playerHealth = playerHealth - bossLaserDamage;
            _hpValueCanvas.text = "HP: " + playerHealth.ToString();
        }

        if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "MiniBoss")
            playerHealth = playerHealth - 5;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "HealthKit")
        {
            Destroy(other.gameObject);
            playerHealth = playerHealth + healthKitRecovery;
            _hpValueCanvas.text = "HP: " + playerHealth.ToString();
        }

        if (other.tag == "Shield")
        {
            _playerShield.SetActive(true);
            _shieldTimer.isShieldCooldown = true;
            _shieldTimer.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BossLaser")
        {
            Instantiate(_enemyHitParticle, transform.position, Quaternion.identity);
            _hpValueCanvas.text = "HP: " + playerHealth.ToString();
            playerHealth = playerHealth - bossLaserDamage;
        }
    }

    private void BossSummon()
	{
		if (playerHealth >= 20 && bossSummonFirstTime == false && _boss.activeInHierarchy == false)
		{
            _bossScript.bossHealth = 25;
            bossSummonFirstTime = true;
			_bossSummonPanel.SetActive(true);
		}

        if (playerHealth >= 30 && bossSummonSevenTime == false && bossSummonSixTime == true && _boss.activeInHierarchy == false)
		{
            _bossScript.bossHealth = 25;
            bossSummonSecondTime = true;
			_bossSummonPanel.SetActive(true);
		}

        if (playerHealth >= 40 && bossSummonSevenTime == false && bossSummonSixTime == true && _boss.activeInHierarchy == false)
		{
            _bossScript.bossHealth = 25;
            bossSummonThirdTime = true;
			_bossSummonPanel.SetActive(true);
		}

        if (playerHealth >= 50 && bossSummonSevenTime == false && bossSummonSixTime == true && _boss.activeInHierarchy == false)
        {
            _bossScript.bossHealth = 25;
            bossSummonFourTime = true;
            _bossSummonPanel.SetActive(true);
        }

        if (playerHealth >= 60 && bossSummonSevenTime == false && bossSummonSixTime == true && _boss.activeInHierarchy == false)
        {
            _bossScript.bossHealth = 25;
            bossSummonFiveTime = true;
            _bossSummonPanel.SetActive(true);
        }

        if (playerHealth >= 70 && bossSummonSevenTime == false && bossSummonSixTime == true && _boss.activeInHierarchy == false)
        {
            _bossScript.bossHealth = 25;
            bossSummonSixTime = true;
            _bossSummonPanel.SetActive(true);
        }

        if (playerHealth >= 80 && bossSummonSevenTime == false && bossSummonSixTime == true && _boss.activeInHierarchy == false)
        {
            _bossScript.bossHealth = 25;
            bossSummonSevenTime = true;
            _bossSummonPanel.SetActive(true);
        }
    }
}
