using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;
    [SerializeField] private CubeValuesAdjuster _cubeValuesAdjuster;

    private Cube[] _createdCubes;
    private float _splitChance = 100f;
    private readonly float _maxSplitChance = 100f;
    private readonly float _splitDivisor = 2f;

    public Cube[] CrearedCubes => _createdCubes;

    public void Create(Transform transform)
    {
        int count = GetRandomCount();

        _createdCubes = new Cube[count];

        for (int i = 0; i < count; i++)
        {
            Cube createdCube = Instantiate(_prefab, transform.position, transform.rotation);
            _cubeValuesAdjuster.Adjust(createdCube, transform);
            _createdCubes[i] = createdCube;
        }

        _splitChance /= _splitDivisor;
    }

    private int GetRandomCount()
    {
        if (_splitChance < Random.Range(0, _maxSplitChance + 1))
            return 0;

        return Random.Range(_minCount, _maxCount + 1);
    }
}
