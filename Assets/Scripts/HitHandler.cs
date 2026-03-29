using UnityEngine;

public class HitHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubesCreator _cubesCreator;
    [SerializeField] private CubesExplosion _cubesExplosion;

    private void Start()
    {
        _raycaster.RaycastHit += CheckHit;
    }

    private void OnDisable()
    {
        _raycaster.RaycastHit -= CheckHit;
    }

    private void CheckHit(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out Cube cube))
        {
            Cube[] cubes = _cubesCreator.Create(cube);
            _cubesExplosion.BlowUp(cubes, cube.transform.position);
            cube.TriggerEvent();
        }
    }
}
