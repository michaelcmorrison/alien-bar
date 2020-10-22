using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public KeyCode useOrbButton;
    public KeyCode throwOrbButton;
    public UnityEvent useOrb;
    public UnityEvent throwOrbAway;

    private void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetKeyDown(useOrbButton))
        {
            useOrb.Invoke();
        }
        else if (Input.GetKeyDown(throwOrbButton))
        {
            throwOrbAway.Invoke();
        }
    }
}