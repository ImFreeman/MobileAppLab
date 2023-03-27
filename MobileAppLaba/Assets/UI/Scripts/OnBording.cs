using UnityEngine;
using UnityEngine.UI;
using System;

public class OnBording : UIWindow
{
    [SerializeField] private GameObject[] _steps;  
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _skipButton;   

    public event EventHandler NextButtonClick;
    public event EventHandler SkipButtonClick;

    public int StepCount => _steps.Length;

    public event EventHandler FinalStep;    

    public override void Show()
    {
        base.Show();

        _nextButton.onClick.AddListener(OnNextButtonClick);
        _skipButton.onClick.AddListener(OnSkipButtonClick);
    }

    public override void Hide()
    {
        base.Hide();

        _nextButton.onClick.RemoveListener(OnNextButtonClick);
        _skipButton.onClick.RemoveListener(OnSkipButtonClick);
    }

    public void SetStep(int id)
    {
        if(id >= _steps.Length)
        {
            FinalStep?.Invoke(this, EventArgs.Empty);
            return;
        }
        for (int i = 0; i < _steps.Length; i++)
        {
            if(i == id)
            {
                _steps[i].SetActive(true);                
            }
            else
            {
                _steps[i].SetActive(false);
            }
        }
    }

    private void OnNextButtonClick()
    {
        NextButtonClick?.Invoke(this, EventArgs.Empty);
    }

    private void OnSkipButtonClick()
    {
        SkipButtonClick?.Invoke(this, EventArgs.Empty);
    }
}
