using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action<RaycastHit> RaycastHit;

    private void Start()
    {
        _inputReader.ButtonPressed += CreateRay;
    }

    private void OnDisable()
    {
        _inputReader.ButtonPressed -= CreateRay;
    }

    private void CreateRay(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
            RaycastHit?.Invoke(hit);
    }
}
