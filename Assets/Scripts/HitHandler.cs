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
        if (hit.transform.TryGetComponent<Cube>(out Cube cube))
        {
            _cubesCreator.Create(hit.transform);
            _cubesExplosion.BlowUp(_cubesCreator.CrearedCubes, cube.transform.position);
            Destroy(cube.gameObject);
        }
    }
}
