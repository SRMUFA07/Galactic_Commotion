using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick _moveJoystick;
    private Rigidbody2D _rigidbody;

    private Vector2 _moveInput;
    private Vector2 _moveVelocity;

    public float playerSpeed;

    public Transform _fireParticlePoint;
    public GameObject _fireParticle;

    public GameObject _playerShield;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Time.timeScale = 0;
    }

    private void Update() => 
        PlayerMove();
    
    private void PlayerMove()
    {
        if (/*YandexSDK.Instance.CurrentDeviceType == Assets.Yandex.DeviceTypeEnum.Desktop*/ ChoosePlatform.pcDevise == true)
        {
            _moveJoystick.gameObject.SetActive(false);
            _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        if (/*YandexSDK.Instance.CurrentDeviceType == Assets.Yandex.DeviceTypeEnum.Mobile*/ ChoosePlatform.pcDevise == false)
        {
            _moveJoystick.gameObject.SetActive(true);
            _moveInput = new Vector2(_moveJoystick.Horizontal, _moveJoystick.Vertical);
        }

        _moveVelocity = _moveInput.normalized * playerSpeed;

        if (_playerShield.activeInHierarchy == true)
            playerSpeed = 3;
        else
            playerSpeed = 5.5f;
    }

    private void FixedUpdate() =>
        _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);
}
