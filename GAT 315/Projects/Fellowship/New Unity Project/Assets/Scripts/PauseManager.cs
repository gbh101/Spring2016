using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    public Canvas canvasPause;
    public GameObject controlls;

    x360_Gamepad gamepad1;
    x360_Gamepad gamepad2;

    private Vector3 offScreen;

    public Button resumeButton;
    public Button htpButton;
    public Button quitButton;


    void Start ()
    {
        gamepad1 = GamepadManager.Instance.GetGamepad(1);
        gamepad2 = GamepadManager.Instance.GetGamepad(2);

        offScreen = new Vector3(0, -600, -281);
    }

    public void TogglePauseMenu()
    {
        if(canvasPause.enabled)
        {
            canvasPause.enabled = false;
            Time.timeScale = 1.0f;
            resumeButton.GetComponent<Button>().enabled = false;
            htpButton.GetComponent<Button>().enabled = false;
            quitButton.GetComponent<Button>().enabled = false;
        }
        else
        {
            canvasPause.enabled = true;
            Time.timeScale = 0.0f;
            resumeButton.GetComponent<Button>().enabled = true;
            htpButton.GetComponent<Button>().enabled = true;
            quitButton.GetComponent<Button>().enabled = true;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            TogglePauseMenu();
            controlls.GetComponent<RectTransform>().anchoredPosition = offScreen;
        }

        if (gamepad1.IsConnected)
        {
            if(gamepad1.GetButtonDown("Start"))
            {
                TogglePauseMenu();
                controlls.GetComponent<RectTransform>().anchoredPosition = offScreen;
            }
        }

        if (gamepad2.IsConnected)
        {
            if (gamepad2.GetButtonDown("Start"))
            {
                TogglePauseMenu();
                controlls.GetComponent<RectTransform>().anchoredPosition = offScreen;
            }
        }
    }
}
