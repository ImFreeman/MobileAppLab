using System.Collections;
using System.Collections.Generic;
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
}
