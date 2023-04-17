using UnityEngine;

public class FirePariclePosition : MonoBehaviour
{
    public Transform _fireParticlePoint;

    private void Update()
    {
        FireParticleAttaching();
    }

    void FireParticleAttaching()
    {
        transform.position = new Vector3(_fireParticlePoint.transform.position.x, _fireParticlePoint.transform.position.y, transform.rotation.z);
    }
}
