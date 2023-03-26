using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenCommand
{
    private readonly TitleScreen _titleScreen;
    private readonly OnBording _onBording;

    public event EventHandler Done;  

    public TitleScreenCommand(TitleScreen titleScreen)
    {
        _titleScreen = titleScreen;       
    }

    public void Do()
    {
        _titleScreen.TimesUp += OnTimesUp;
    }

    private void OnTimesUp(object sender, EventArgs e)
    {
        _titleScreen.Hide();
        _onBording.Show();
    }
}
