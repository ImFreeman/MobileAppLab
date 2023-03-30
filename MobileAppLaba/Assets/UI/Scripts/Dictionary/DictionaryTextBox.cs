using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DictionaryTextBox : MonoBehaviour
{
    [SerializeField] private TMP_Text _firstText;
    [SerializeField] private TMP_Text _secondText;

    public void SetContent(string first, string second)
    {
        _firstText.text = first;
        _secondText.text = second;
    }
}
