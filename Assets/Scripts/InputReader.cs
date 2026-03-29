using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string _actionButton = "Fire1";

    public event Action<Ray> ButtonPressed;

    private void Update()
    {
        if (Input.GetButtonDown(_actionButton))
            ButtonPressed?.Invoke(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
