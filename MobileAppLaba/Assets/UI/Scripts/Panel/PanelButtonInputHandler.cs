using System;
using System.Collections.Generic;
using UnityEngine;

public class PanelButtonInputHandler : MonoBehaviour
{
    [SerializeField] private PanelButton[] _buttons;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _activeColor;
    
    private Dictionary<PanelButtonType, PanelButton> _buttonsDict;

    public event EventHandler<PanelButtonType> ButtonClicked;

    private void Awake()
    {
        _buttonsDict = new Dictionary<PanelButtonType, PanelButton>();
    }

    private void OnEnable()
    {
        foreach (PanelButton button in _buttons)
        {
            button.ClickEvent += HandleClick;
            _buttonsDict.Add(button.Type, button);
        }
    }

    public void ClickButton(PanelButtonType type)
    {
        HandleClick(_buttonsDict[type], EventArgs.Empty);
    }

    private void HandleClick(object sender, EventArgs e)
    {
        var button = sender as PanelButton;
        if (button == null)
        {
            return;
        }

        var type = button.Type;
        foreach (var key in _buttonsDict.Keys)
        {
            if (type != key)
            {
                _buttonsDict[key].SetInactiveSprite();
                _buttonsDict[key].SetTextColor(_defaultColor);
            }
        }
        _buttonsDict[type].SetActiveSprite();
        _buttonsDict[type].SetTextColor(_activeColor);
        ButtonClicked?.Invoke(this, type);
    }

    private void OnDisable()
    {
        foreach (PanelButton button in _buttons)
        {
            button.ClickEvent -= HandleClick;
        }
    }

    private void OnDestroy()
    {
        _buttonsDict.Clear();
    }
}
