using UnityEngine;

public class HitHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubesCreator _cubesCreator;
    [SerializeField] private CubesExplosion _cubesExplosion;

    private void Start()
    {
        _raycaster.RaycastHit += HitCube;
    }

    private void OnDisable()
    {
        _raycaster.RaycastHit -= HitCube;
    }

    private void HitCube(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out Cube cube))
        {
            Cube[] cubes = _cubesCreator.Create(cube);
            _cubesExplosion.BlowUp(cubes, cube.transform.position);
            _cubesCreator.DestroyCube(cube);
        }
    }
}
