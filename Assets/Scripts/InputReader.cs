using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Ray> ButtonPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ButtonPressed?.Invoke(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
