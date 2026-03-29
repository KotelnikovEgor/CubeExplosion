using UnityEngine;

public class CubesExplosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void BlowUp(Cube[] cubes, Vector3 position)
    {
        foreach (var cube in cubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_force, position, _radius);
        }
    }
}
