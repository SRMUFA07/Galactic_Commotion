using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public AudioSource _laserShot;
    
    public float offset;
    private float _rotationZ;

    public Joystick _shotJoystick;

    public GameObject _laserDouble;
    public Transform _gunPoint;

    private float _timeShot;
    public float delayBetweenShots;

    public ChoosePlatform _platform;

    private void Update() 
    {
        RechageCheck();
        PlayerRotation();
        PlatformCheck();
    }

    public void Shoot()
    {
        Instantiate(_laserDouble, _gunPoint.position, transform.rotation);
        _timeShot = delayBetweenShots;
    }

    private void PlayerRotation()
    {
        if (_platform.pcDevise == true)
        {
            Vector3 _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            _rotationZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        }
        else if (_platform.pcDevise == false)
            if (Mathf.Abs(_shotJoystick.Horizontal) > 0.3f || Mathf.Abs(_shotJoystick.Vertical) > 0.3f)
                _rotationZ = Mathf.Atan2(_shotJoystick.Vertical, _shotJoystick.Horizontal) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0f, 0f, _rotationZ + offset);
    }

    private void RechageCheck()
    {
        if (_timeShot <= 0)
        {
            if (_shotJoystick.Horizontal != 0 || _shotJoystick.Vertical != 0 && _platform.pcDevise == false)
            {
                _laserShot.Play();
                Shoot();
            }

            if (Input.GetMouseButton(0) && _platform.pcDevise == true)
            {
                _laserShot.Play();
                Shoot();
            }
        }
        else
            _timeShot -= Time.deltaTime;
    }

    private void PlatformCheck()
    {
        if (_platform.pcDevise == true)
            _shotJoystick.gameObject.SetActive(false);
    }
}