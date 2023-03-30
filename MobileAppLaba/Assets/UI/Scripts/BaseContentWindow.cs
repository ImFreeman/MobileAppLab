using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseContentWindow : UIWindow
{
    [SerializeField] private PanelButtonType _type;

    public PanelButtonType Type => _type;
}
