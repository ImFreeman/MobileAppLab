using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TitleScreen _titleScreen;
    [SerializeField] private OnBording _onBording;
    [SerializeField] private LoginScreen _loginScreen;

    private TitleScreenController _titleScreenCommand;
    private OnBordingController _onBordingController;

    private void Awake()
    {
        _titleScreenCommand = new TitleScreenController(_titleScreen, _onBording);        
        _titleScreenCommand.Done += OnTitleScreenCommandDone;

        _onBordingController = new OnBordingController(_onBording, _loginScreen);
        _onBordingController.Done += OnBordingControllerDone;
    }

    private void OnBordingControllerDone(object sender, System.EventArgs e)
    {
        _onBordingController.Done -= OnBordingControllerDone;
        _onBordingController.Dispose();
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
