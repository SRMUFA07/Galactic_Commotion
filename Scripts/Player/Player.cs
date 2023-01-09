using UnityEngine;
using System.Runtime.InteropServices;

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

    public ChoosePlatform _platform;

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Time.timeScale = 0;
        ShowAdv();
    }

    private void Update()
    {
        PlayerMove();
    }
    
    private void PlayerMove()
    {
        if (_platform.pcDevise == true)
        {
            _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _moveJoystick.gameObject.SetActive(false);
        }

        if (_platform.pcDevise == false)
            _moveInput = new Vector2(_moveJoystick.Horizontal, _moveJoystick.Vertical);

        _moveVelocity = _moveInput.normalized * playerSpeed;

        if (_playerShield.activeInHierarchy == true)
            playerSpeed = 3;
        else
            playerSpeed = 5.5f;
    }

    private void FixedUpdate() 
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);
    }
}
