using System.Collections.Generic;
using UnityEngine;

public class CubesExplosion : MonoBehaviour
{
    [SerializeField] private float _initialRadius;
    [SerializeField] private float _initialForce;

    public void ExplodeCreated(Cube[] cubes, Vector3 position)
    {
        foreach (var cube in cubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_initialForce, position, _initialRadius);
        }
    }

    public void ExplodeInSphere(Vector3 position, Vector3 scale)
    {
        foreach (Rigidbody cube in GetCubesInSphere(position))
        {
            float force = _initialForce / scale.x;
            float radius = _initialRadius / scale.x;
            cube.AddExplosionForce(force, position, radius);
        }
    }

    private List<Rigidbody> GetCubesInSphere(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, _initialRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.TryGetComponent(out Cube cube))
                if (cube.TryGetComponent(out Rigidbody rigidbody))
                    cubes.Add(rigidbody);

        return cubes;
    }
}
