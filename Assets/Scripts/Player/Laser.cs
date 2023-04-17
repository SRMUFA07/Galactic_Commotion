using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserSpeed;
    public float laserLifeTime;

    private void Start() => Invoke("DestroyLaser", laserLifeTime);

    private void Update() => transform.Translate(Vector2.up * laserSpeed * Time.deltaTime);

    public void DestroyLaser() => Destroy(gameObject);
}
