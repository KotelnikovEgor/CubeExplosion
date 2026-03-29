using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;
    [SerializeField] private Colorizer _colorizer;

    private readonly float _splitDivisor = 2f;
    private readonly float _scaleDivisor = 2f;

    public Cube[] Create(Cube cube)
    {
        int count = 0;

        if (cube.CanSplit())
            count = GenerateCount();

        Cube[] createdCubes = new Cube[count];

        for (int i = 0; i < count; i++)
        {
            Cube createdCube = Instantiate(_prefab, cube.transform.position, cube.transform.rotation);
            createdCube.SetSplitChance(cube.SplitChance / _splitDivisor);
            SetScale(createdCube, cube.transform.localScale / _scaleDivisor);
            _colorizer.Colorize(createdCube);
            createdCubes[i] = createdCube;
        }

        return createdCubes;
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    private int GenerateCount()
    {
        return Random.Range(_minCount, _maxCount + 1);
    }

    private void SetScale(Cube cube, Vector3 scale)
    {
        cube.transform.localScale = scale;
    }
}
