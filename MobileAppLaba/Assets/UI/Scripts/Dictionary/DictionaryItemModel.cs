using System;
using UnityEngine;

[Serializable]
public struct Meaning
{
    public string FirstText;
    public string SecondText;
}

[CreateAssetMenu(fileName = "DictionaryItemModel", menuName = "ScriptableObjects/DictionaryItemModel", order = 1)]
public class DictionaryItemModel : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private string _partOfSpeech;
    [SerializeField] private Meaning[] _meanings;
    
    public string Title => _title;

    public string PartOfSpeech => _partOfSpeech;

    public Meaning[] Meanings => _meanings;
}
