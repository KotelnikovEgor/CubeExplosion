using UnityEngine;

[RequireComponent(typeof(Cube))]
public class CubesCreator : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;

    private Cube _cube;
    private int _count;
    private readonly float _maxChance = 100f;

    private void Start()
    {
        _cube = GetComponent<Cube>();
    }

    private void SetValues(GameObject cube)
    {
        Vector3 newCubeScale = transform.localScale / 2;
        cube.transform.localScale = newCubeScale;
        cube.GetComponent<Renderer>().material.color = GetRandomColor();
        cube.GetComponent<Cube>().SeparationChance = _cube.SeparationChance / 2;
    }

    private int GetRandomCount()
    {
        if (_cube.SeparationChance <= Random.Range(0, _maxChance + 1))
            return 0;

        return Random.Range(_minCount, _maxCount + 1);
    }

    private Color GetRandomColor()
    {
        return Random.ColorHSV();
    }

    public void Create(out GameObject[] newCubes)
    {
        _count = GetRandomCount();
        newCubes = new GameObject[_count];

        if (_count == 0)
            return;

        for (int i = 0; i < _count; i++)
        {
            GameObject newCube = Instantiate(_cubePrefab, transform.position, transform.rotation);
            SetValues(newCube);
            newCubes[i] = newCube;
        }
    }
}
