using UnityEngine;

[RequireComponent(typeof(CubesCreator))]
public class Cube : MonoBehaviour
{
    private CubesCreator _cubesCreator;
    private Explosion _explosion;
    private GameObject[] _explodingCubes;

    public float SeparationChance = 100f;

    private void Start()
    {
        _cubesCreator = GetComponent<CubesCreator>();
        _explosion = GetComponent<Explosion>();
    }

    private void OnMouseDown()
    {
        _cubesCreator.Create(out _explodingCubes);

        if (_explodingCubes.Length > 0)
            _explosion.Explode(_explodingCubes);

        Destroy(gameObject);
    }
}
