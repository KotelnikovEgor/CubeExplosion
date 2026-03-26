using UnityEngine;

public class CubeValuesAdjuster : MonoBehaviour
{
    private readonly float _scaleDivisor = 2f;

    public void Adjust(Cube cube, Transform destroyedTransform)
    {
        Vector3 cubeScale = destroyedTransform.localScale / _scaleDivisor;
        cube.transform.localScale = cubeScale;

        if (cube.TryGetComponent<Renderer>(out Renderer renderer)) 
            renderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return Random.ColorHSV();
    }
}
