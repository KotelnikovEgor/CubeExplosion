using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private readonly float _maxSplitChance = 100f;

    public float SplitChance { get; private set; } = 100f;

    public void SetSplitChance(float value)
    {
        SplitChance = value;
    }

    public bool CanSplit()
    {
        return SplitChance >= Random.Range(0, _maxSplitChance + 1);
    }
}
