using UnityEngine;

public class CubeHitCheck : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubesCreator _cubesCreator;

    private void Start()
    {
        _raycaster.RaycastHit += CheckHit;
    }

    private void CheckHit(RaycastHit hit)
    {
        if (hit.transform.GetComponent<Cube>())
        {
            _cubesCreator.Create(hit.transform);
            Destroy(hit.transform.gameObject);
        }
    }
}
