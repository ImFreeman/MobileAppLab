using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoWindow : BaseContentWindow
{
    private const string StartURL = "https://learnenglish.britishcouncil.org/general-english/video-zone";
    [SerializeField] private WebViewService _webViewService;
    
    public override void Show()
    {
        base.Show();
        ShowWeb();
    }
    public override void Hide()
    {
        base.Hide();
        _webViewService.HideVebView();
    }
    private void ShowWeb()
    {
        _webViewService.ShowVebView(StartURL);
    }
}
