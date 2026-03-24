using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;
    [SerializeField] private CubesExplosion _cubesExplosion;

    private int _count;
    private float _splitChance = 100f;
    private readonly float _maxSplitChance = 100f;
    private readonly float _splitDivisor = 2f;

    public void Create(Transform transform)
    {
        _count = GetRandomCount();

        Cube[] createdCubes = new Cube[_count];

        if (_count == 0)
            return;

        for (int i = 0; i < _count; i++)
        {
            Cube createdCube = Instantiate(_cubePrefab, transform.position, transform.rotation);
            SetValues(createdCube, transform);
            createdCubes[i] = createdCube;
        }

        _splitChance /= _splitDivisor;
        _cubesExplosion.BlowUp(createdCubes, transform.position);
    }

    private void SetValues(Cube cube, Transform destroyedTransform)
    {
        Vector3 cubeScale = destroyedTransform.localScale / 2;
        cube.transform.localScale = cubeScale;
        cube.GetComponent<Renderer>().material.color = GetRandomColor();
    }

    private int GetRandomCount()
    {
        if (_splitChance < Random.Range(0, _maxSplitChance + 1))
            return 0;

        return Random.Range(_minCount, _maxCount + 1);
    }

    private Color GetRandomColor()
    {
        return Random.ColorHSV();
    }
}
