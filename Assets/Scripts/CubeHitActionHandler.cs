using UnityEngine;

public class CubeHitActionHandler : MonoBehaviour
{
    [SerializeField] private CubesCreator _cubesCreator;
    [SerializeField] private CubesExplosion _cubesExplosion;

    public void Process(Cube cube)
    {
        if (cube.CanSplit())
        {
            Cube[] cubes = _cubesCreator.Create(cube);
            _cubesExplosion.ExplodeCreated(cubes, cube.transform.position);
            _cubesCreator.DestroyCube(cube);
        }
        else
        {
            _cubesExplosion.ExplodeInSphere(cube.transform.position, cube.transform.localScale);
            _cubesCreator.DestroyCube(cube);
        }
    }
}
