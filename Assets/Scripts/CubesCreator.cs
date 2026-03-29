using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;
    [SerializeField] private Colorizer _cubeValuesAdjuster;
    [SerializeField] private Cube[] _firstCubes;

    private Cube[] _createdCubes;
    private readonly float _scaleDivisor = 2f;

    private void Start()
    {
        SubscribeFirstCubes();
    }

    public Cube[] Create(Cube cube)
    {
        int count = 0;

        if (cube.CanSplit())
            count = GenerateCount();

        _createdCubes = new Cube[count];

        for (int i = 0; i < count; i++)
        {
            Cube createdCube = Instantiate(_prefab, cube.transform.position, cube.transform.rotation);
            createdCube.OnClick += DestroyCube;
            createdCube.SetSplitChance(cube);
            SetScale(createdCube, cube.transform);
            _cubeValuesAdjuster.Colorize(createdCube);
            _createdCubes[i] = createdCube;
        }

        return _createdCubes;
    }

    private void SubscribeFirstCubes()
    {
        foreach (var cube in _firstCubes)
            cube.OnClick += DestroyCube;
    }

    private int GenerateCount()
    {
        return Random.Range(_minCount, _maxCount + 1);
    }

    private void DestroyCube(Cube cube)
    {
        cube.OnClick -= DestroyCube;
        Destroy(cube.gameObject);
    }

    private void SetScale(Cube cube, Transform destroyedTransform)
    {
        Vector3 cubeScale = destroyedTransform.localScale / _scaleDivisor;
        cube.transform.localScale = cubeScale;
    }
}
