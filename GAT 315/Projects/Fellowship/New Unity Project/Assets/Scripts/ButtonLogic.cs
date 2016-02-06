using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ButtonLogic : MonoBehaviour
{
    public GameObject canvasPause;
    public GameObject confimationBox;
    public GameObject controlls;

    private Vector3 onScreen;
    private Vector3 offScreen;

    public Button yesButton;
    public Button noButton;
    public Button resumeButton;
    public Button htpButton;
    public Button quitButton;

    public bool controllsVisible = false;

    void Awake()
    {
        onScreen = new Vector3(0, 0, -281);
        offScreen = new Vector3(0, -600, -281);

        yesButton.GetComponent<Button>().enabled = false;
        noButton.GetComponent<Button>().enabled = false;
    }

    public void ResumeGame()
    {
        canvasPause.GetComponent<PauseManager>().TogglePauseMenu();
        resumeButton.GetComponent<Button>().enabled = false;
        htpButton.GetComponent<Button>().enabled = false;
        quitButton.GetComponent<Button>().enabled = false;
    }
    
    public void HowToPlay()
    {
        ToggleControlls();
    }

    public void QuitGame()
    {
        confimationBox.GetComponent<RectTransform>().anchoredPosition = onScreen;
        yesButton.GetComponent<Button>().enabled = true;
        noButton.GetComponent<Button>().enabled = true;
        resumeButton.GetComponent<Button>().enabled = false;
        htpButton.GetComponent<Button>().enabled = false;
        quitButton.GetComponent<Button>().enabled = false;

    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        confimationBox.GetComponent<RectTransform>().anchoredPosition = offScreen;
        yesButton.GetComponent<Button>().enabled = false;
        noButton.GetComponent<Button>().enabled = false;
        resumeButton.GetComponent<Button>().enabled = true;
        htpButton.GetComponent<Button>().enabled = true;
        quitButton.GetComponent<Button>().enabled = true;
    }

    public void ToggleControlls()
    {
        if(controllsVisible)
        {
            controlls.GetComponent<RectTransform>().anchoredPosition = offScreen;
            resumeButton.GetComponent<Button>().enabled = true;
            quitButton.GetComponent<Button>().enabled = true;
        }
        else
        {
            controlls.GetComponent<RectTransform>().anchoredPosition = onScreen;
            resumeButton.GetComponent<Button>().enabled = false;
            quitButton.GetComponent<Button>().enabled = false;
        }
    }
}
