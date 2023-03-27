using System;

public class TitleScreenController : IDisposable
{
    private readonly TitleScreen _titleScreen;
    private readonly OnBording _onBording;

    private bool _handled;

    public event EventHandler Done;

    public TitleScreenController(TitleScreen titleScreen, OnBording onBording)
    {
        _titleScreen = titleScreen;
        _onBording = onBording;
    }

    public void Do()
    {
        _titleScreen.Show();
        _titleScreen.TimesUp += OnTimesUp;
        _handled = true;
    }

    private void OnTimesUp(object sender, EventArgs e)
    {
        _titleScreen.Hide();
        _onBording.Show();
        _titleScreen.TimesUp -= OnTimesUp;
        _handled = false;
        Done?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose()
    {
        if(_handled)
        {
            _titleScreen.TimesUp -= OnTimesUp;
        }       
    }
}
