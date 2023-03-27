using FantomLib;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : UIWindow
{
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private Button _showPasswordButton;

    [SerializeField] private Image _showPasswordButtonImage;
    [SerializeField] private Sprite _showPasswordSprite;
    [SerializeField] private Sprite _hidePasswordSprite;

    [SerializeField] private Button _signUpButton;
    [SerializeField] private Button _logInButton;

    [SerializeField] private OKDialogController _oKDialogController;

    private bool _showPassword;    

    private bool ShowPassword
    {
        get => _showPassword;
        set
        {
            if(value)
            {
                _password.contentType = TMP_InputField.ContentType.Standard;
                _showPasswordButtonImage.sprite = _showPasswordSprite;
            }
            else
            {
                _password.contentType = TMP_InputField.ContentType.Password;
                _showPasswordButtonImage.sprite = _hidePasswordSprite;
            }
            _showPassword = value;
        }
    }

    public event EventHandler SignedUp;    

    private void OnEnable()
    {
        _showPasswordButton.onClick.AddListener(OnShowPasswordButtonClick);
        _signUpButton.onClick.AddListener(OnSignUpButtonClick);
        _logInButton.onClick.AddListener(OnSignUpButtonClick);
    }    

    private void OnSignUpButtonClick()
    {
        if(!string.IsNullOrEmpty(_name.text) && !string.IsNullOrEmpty(_email.text) && !string.IsNullOrEmpty(_password.text))
        {
            SignedUp?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            //dialogue
            _oKDialogController.Show();
        }
    }

    private void OnShowPasswordButtonClick()
    {
        ShowPassword = !_showPassword;
    }

    private void OnDisable()
    {
        _showPasswordButton.onClick.RemoveListener(OnShowPasswordButtonClick);
        _signUpButton.onClick.RemoveListener(OnSignUpButtonClick);
        _logInButton.onClick.RemoveListener(OnSignUpButtonClick);
    }
}
