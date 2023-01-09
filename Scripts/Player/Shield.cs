using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float shieldCooldown;
    [HideInInspector] public bool isShieldCooldown;

    public Image _shieldTimeCanvas;
    public GameObject _playerShield;

    private void Start()
    {
        _shieldTimeCanvas = GetComponent<Image>();
    }

    private void Update() 
    {
        CheckShieldColldown();
    }

    public void ResetShieldTimer() 
    {
        _shieldTimeCanvas.fillAmount = 1;
    }

    private void CheckShieldColldown()
    {
        if (isShieldCooldown == true)
        {
            _shieldTimeCanvas.fillAmount -= 1 / shieldCooldown * Time.deltaTime;

            if (_shieldTimeCanvas.fillAmount <= 0)
            {
                _shieldTimeCanvas.fillAmount = 1;
                isShieldCooldown = false;
                _playerShield.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
