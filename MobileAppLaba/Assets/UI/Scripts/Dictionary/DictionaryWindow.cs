using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryWindow : BaseContentWindow
{
    [SerializeField] private TMP_InputField _searchField;
    [SerializeField] private Button _searchButton;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _partOfSpeechText;
    [SerializeField] private DictionaryTextBox _firstTextBox;
    [SerializeField] private DictionaryTextBox _secondTextBox;
    [SerializeField] private DictionaryItemConfig _config;

    private void OnEnable()
    {
        _searchButton.onClick.AddListener(OnSearchButtonClick);
    }

    private void OnSearchButtonClick()
    {
        var model = _config.Get(_searchField.text);
        if(model == null)
        {
            model = _config.Placeholder;
        }
        SetModel(model);
    }

    private void SetModel(DictionaryItemModel model)
    {
        _title.text = model.Title;
        _partOfSpeechText.text = model.PartOfSpeech;
        _firstTextBox.SetContent(model.Meanings[0].FirstText, model.Meanings[0].SecondText);
        _secondTextBox.SetContent(model.Meanings[1].FirstText, model.Meanings[1].SecondText);
    }

    private void OnDisable()
    {
        _searchButton.onClick.RemoveListener(OnSearchButtonClick);
    }
}
