using System;
using UnityEngine;
using UnityEngine.Serialization;

public class OnBoardingInputHandler : MonoBehaviour
{
    [SerializeField] private SwipeController swipeController;
    [SerializeField] private OnBording onBording;
    [FormerlySerializedAs("swipeDirection")] [SerializeField] private SwipeDirection swipeDirectionNextPage;
    [SerializeField] private SwipeDirection swipeDirectionPrevPage;

    private int _currentStep = 0;

    private void OnEnable()
    {
        onBording.NextButtonClick += OnNextButtonClick;
        onBording.SkipButtonClick += OnSkipButtonClick;
        swipeController.Swiped += OnSwiped;
    }

    private void Start()
    {
        onBording.SetStep(_currentStep);
    }

    private void OnSwiped(object sender, SwipeDirection e)
    {
        if(e == swipeDirectionNextPage)
        {
            NextPage();
        }
        else if (e == swipeDirectionPrevPage)
        {
            PrevPage();
        }
    }

    private void OnSkipButtonClick(object sender, System.EventArgs e)
    {
        Skip();
    }

    private void OnNextButtonClick(object sender, System.EventArgs e)
    {
        NextPage();
    }

    private void NextPage()
    {
        _currentStep++;
        onBording.SetStep(_currentStep);
    }

    private void PrevPage()
    {
        _currentStep = Math.Max(_currentStep - 1, 0);
        onBording.SetStep(_currentStep);
    }

    private void Skip()
    {
        _currentStep = onBording.StepCount;
        onBording.SetStep(_currentStep);
    }

    private void OnDisable()
    {
        onBording.NextButtonClick -= OnNextButtonClick;
        onBording.SkipButtonClick -= OnSkipButtonClick;
        swipeController.Swiped -= OnSwiped;
    }
}
