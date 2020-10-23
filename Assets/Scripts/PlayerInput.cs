using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public KeyCode useOrbButton;
    public KeyCode throwOrbButton;
    public KeyCode pauseButton;
    public UnityEvent useOrb;
    public UnityEvent throwOrbAway;

    private void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetKeyDown(useOrbButton) && GameManager.Instance.gameRunning)
        {
            useOrb.Invoke();
        }
        else if (Input.GetKeyDown(throwOrbButton) && GameManager.Instance.gameRunning)
        {
            throwOrbAway.Invoke();
        }
        else if (Input.GetKeyDown(pauseButton))
        {
            if (GameManager.Instance.gameRunning)
            {
                GameManager.Instance.Pause();
            }
            else
            {
                GameManager.Instance.Unpause();
            }
        }
    }
}