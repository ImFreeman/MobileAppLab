using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TitleScreen _titleScreen;
    [SerializeField] private OnBording _onBording;
    [SerializeField] private LoginScreen _loginScreen;
    [SerializeField] private Panel _panel;
    [SerializeField] private BaseContentWindow[] _windows;

    private TitleScreenController _titleScreenCommand;
    private OnBordingController _onBordingController;
    private Dictionary<PanelButtonType, UIWindow> _contentWindows;

    private void Awake()
    {
        _contentWindows = new Dictionary<PanelButtonType, UIWindow>();
        foreach (BaseContentWindow window in _windows)
        {
            _contentWindows.Add(window.Type, window);
        }
        
        _titleScreenCommand = new TitleScreenController(_titleScreen, _onBording);        
        _titleScreenCommand.Done += OnTitleScreenCommandDone;

        _onBordingController = new OnBordingController(_onBording, _loginScreen);
        _onBordingController.Done += OnBordingControllerDone;
        
        _panel.ButtonClicked += PanelOnButtonClicked;
    }

    private void PanelOnButtonClicked(object sender, PanelButtonType e)
    {
        ChoiceContentWindow(e);
    }

    private void ChoiceContentWindow(PanelButtonType type)
    {
        foreach (var key in _contentWindows.Keys)
        {
            if (key != type)
            {
                _contentWindows[key].Hide();
            }
        }
        _contentWindows[type].Show();
    }

    private void OnBordingControllerDone(object sender, System.EventArgs e)
    {
        _onBordingController.Done -= OnBordingControllerDone;
        _onBordingController.Dispose();
        
        _loginScreen.SignedUp += LoginScreenOnSignedUp;
        
    }

    private void LoginScreenOnSignedUp(object sender, EventArgs e)
    {
        _loginScreen.SignedUp -= LoginScreenOnSignedUp;
        _loginScreen.Hide();
        _panel.Show();
        _panel.ClickButton(PanelButtonType.Dictionary);
    }

    private void OnTitleScreenCommandDone(object sender, System.EventArgs e)
    {
        _titleScreenCommand.Done -= OnTitleScreenCommandDone;
        _titleScreenCommand.Dispose();

        _onBordingController.Do();
    }

    private void Start()
    {
        _titleScreenCommand.Do();
    }   
}
