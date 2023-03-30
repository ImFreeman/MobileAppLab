using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum PanelButtonType
{
    Dictionary,
    Training,
    Video
}

public class PanelButton : MonoBehaviour
{
    [SerializeField] private PanelButtonType _type;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _inactiveSprite;

    public event EventHandler ClickEvent;

    public PanelButtonType Type => _type;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickHandler);
    }

    public void SetActiveSprite()
    {
        _image.sprite = _activeSprite;
    }

    public void SetInactiveSprite()
    {
        _image.sprite = _inactiveSprite;
    }

    public void SetTextColor(Color color)
    {
        _text.color = color;
    }

    private void OnClickHandler()
    {
        ClickEvent?.Invoke(this, EventArgs.Empty);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickHandler);
    }
}
