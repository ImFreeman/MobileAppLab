using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : UIWindow
{
    [SerializeField] private  PanelButtonInputHandler _inputHandler;

    public event EventHandler<PanelButtonType> ButtonClicked;

    private void OnEnable()
    {
        _inputHandler.ButtonClicked += InputHandlerOnButtonClicked;
    }

    private void InputHandlerOnButtonClicked(object sender, PanelButtonType e)
    {
        ButtonClicked?.Invoke(this, e);
    }

    public void ClickButton(PanelButtonType type)
    {
        _inputHandler.ClickButton(type);
    }

    private void OnDisable()
    {
        _inputHandler.ButtonClicked += InputHandlerOnButtonClicked;
    }
}
