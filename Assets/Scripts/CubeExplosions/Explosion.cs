using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void Explode(GameObject[] cubes)
    {
        foreach (GameObject cube in cubes)
            cube.GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius);
    }
}
