using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBordingController : IDisposable
{
    private readonly OnBording _onBording;
    private readonly LoginScreen _loginScreen;

    private bool _handled;

    public event EventHandler Done;
    public OnBordingController(OnBording onBording, LoginScreen loginScreen)
    {
        _onBording = onBording;
        _loginScreen = loginScreen;
    }

    public void Do()
    {
        _onBording.FinalStep += OnFinalStep;
        _handled = true;
    }

    private void OnFinalStep(object sender, EventArgs e)
    {
        _onBording.FinalStep -= OnFinalStep;
        _handled = false;
        _onBording.Hide();
        _loginScreen.Show();        
        Done?.Invoke(this, EventArgs.Empty);        
    }

    public void Dispose()
    {
        if(_handled)
        {
            _onBording.FinalStep -= OnFinalStep;
        }       
    }
}
