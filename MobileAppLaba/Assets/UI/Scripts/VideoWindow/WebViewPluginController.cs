using UnityEngine;

public class WebViewPluginController
{
    private const string PluginName = "com.example.webviewplugin.WebViewPlugin";
    private readonly AndroidJavaClass _pluginClass;
    private readonly AndroidJavaObject _pluginInstance;

    public WebViewPluginController()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _pluginClass = CreatePluginClass();
            _pluginInstance = CreatePluginInstance(_pluginClass);
        }
    }
    private AndroidJavaClass CreatePluginClass()
    {
        var pluginClass = new AndroidJavaClass(PluginName);
        AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
        pluginClass.SetStatic("mainActivity", activity);
        return pluginClass;
    }

    private AndroidJavaObject CreatePluginInstance(AndroidJavaClass pluginClass)
    {
        var pluginInstance = pluginClass.CallStatic<AndroidJavaObject>("getInstance");
        return pluginInstance;
    }

    public void OpenWebView(string URL, int pixelShift)
    {
        if (Application.platform == RuntimePlatform.Android)
            _pluginInstance.Call("showWebView", new object[] { URL, pixelShift });
    }

    public void CloseWebView()
    {
        if (Application.platform == RuntimePlatform.Android)
            _pluginInstance.Call("closeWebView");
    }
}
