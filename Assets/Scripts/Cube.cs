using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private float _splitChance = 100f;
    private readonly float _splitDivisor = 2f;
    private readonly float _maxSplitChance = 100f;

    public event Action<Cube> OnClick;

    public float SplitChance => _splitChance;

    public void TriggerEvent()
    {
        OnClick?.Invoke(this);
    }

    public void SetSplitChance(Cube destroyedCube)
    {
        _splitChance = destroyedCube.SplitChance / _splitDivisor;
    }

    public bool CanSplit()
    {
        if (SplitChance >= UnityEngine.Random.Range(0, _maxSplitChance + 1))
            return true;

        return false;
    }
}
