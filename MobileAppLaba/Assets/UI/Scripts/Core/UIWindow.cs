using System;
using UnityEngine;

public abstract class UIWindow : MonoBehaviour
{
    public event EventHandler ShowEvent;
    public event EventHandler HideEvent;

    public virtual void Show()
    {
        gameObject.SetActive(true);
        ShowEvent?.Invoke(this, EventArgs.Empty);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        HideEvent?.Invoke(this, EventArgs.Empty);
    }

    protected void OnShow()
    {
        ShowEvent?.Invoke(this, EventArgs.Empty);
    }

    protected void OnHide()
    {
        HideEvent?.Invoke(this, EventArgs.Empty);
    }  
}
