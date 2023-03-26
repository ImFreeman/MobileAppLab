using System;
using System.Collections;
using UnityEngine;

public class TitleScreen : UIWindow
{
    [SerializeField] private float _timeBorder;

    private float _currentTime;
    private Coroutine _coroutine;

    public event EventHandler TimesUp; 

    public override void Show()
    {
        base.Show();
        _coroutine = StartCoroutine(Timer());
    }

    public override void Hide()
    {
        base.Hide();
        StopCoroutine(_coroutine);
    }   

    private IEnumerator Timer()
    {
        while(_currentTime <= _timeBorder)
        {
            _currentTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        TimesUp?.Invoke(this, EventArgs.Empty);
    }
}
