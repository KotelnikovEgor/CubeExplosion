using UnityEngine;

public class HitHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeHitActionHandler _cubeHitActionHandler;

    private void Start()
    {
        _raycaster.RaycastHit += ProcessHit;
    }

    private void OnDisable()
    {
        _raycaster.RaycastHit -= ProcessHit;
    }

    private void ProcessHit(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out Cube cube))
        {
            _cubeHitActionHandler.Process(cube);
        }
    }
}
