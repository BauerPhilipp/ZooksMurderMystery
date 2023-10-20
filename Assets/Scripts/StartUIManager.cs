using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartUIManager : MonoBehaviour
{

    VisualElement root;

    Button startButton;
    Button settingsButton;
    Button credtitsButton;
    Button exitButton;

    VisualElement settingsCanvas;
    VisualElement creditsCanvas;
    VisualElement buttonsCanvas;

    List<VisualElement> canvasList;

    Color colorBlue = new Color32(0,45,125,230);
    Color colorRed = new Color32(125,0,0,230);

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("StartButton");
        settingsButton = root.Q<Button>("SettingsButton");
        credtitsButton = root.Q<Button>("CreditsButton");
        exitButton = root.Q<Button>("ExitButton");

        settingsCanvas = root.Q("SettingsCanvas");
        creditsCanvas = root.Q("CreditsCanvas");
        buttonsCanvas = root.Q("ButtonsCanvas");
        canvasList = new List<VisualElement>() { settingsCanvas, creditsCanvas};

        startButton.RegisterCallback<ClickEvent>(StartButtonClicked);
        settingsButton.RegisterCallback<ClickEvent>(SettingsButtonClicked);
        credtitsButton.RegisterCallback<ClickEvent>(CreditsButtonClicked);
        exitButton.RegisterCallback<ClickEvent>(ExitButtonClicked);

    }

    private void Start()
    {
        SetCanvasInvisible();
    }

    private void SetCanvasInvisible()
    {
        foreach (VisualElement element in canvasList)
        {
            element.visible = false;
        }
    }

    private void StartButtonClicked(ClickEvent e)
    {
        Debug.Log("Start clicked!");
    }

    private void SettingsButtonClicked(ClickEvent e)
    {
        if (settingsCanvas.visible)
        {
            settingsCanvas.visible = false;
            return;
        }
        SetCanvasInvisible();
        Debug.Log("Settings clicked!");
        settingsCanvas.visible = true;
        creditsCanvas.style.backgroundColor = colorRed;
        buttonsCanvas.style.backgroundColor = colorRed;

    }

    private void CreditsButtonClicked(ClickEvent e)
    {
        if (creditsCanvas.visible)
        {
            creditsCanvas.visible = false;
            return;
        }
        SetCanvasInvisible();
        Debug.Log("Credits clicked!");
        creditsCanvas.visible = true;
        creditsCanvas.style.backgroundColor = colorBlue;
        buttonsCanvas.style.backgroundColor = colorBlue;
    }

    private void ExitButtonClicked(ClickEvent e)
    {
        Debug.Log("Exit clicked!");
        Application.Quit();
    }

}
