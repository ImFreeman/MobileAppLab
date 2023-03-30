using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DictionaryItemConfig", menuName = "ScriptableObjects/DictionaryItemConfig", order = 1)]
public class DictionaryItemConfig : ScriptableObject
{
    [SerializeField] private DictionaryItemModel _placeholderModel;

    [SerializeField] private DictionaryItemModel[] _models;

    [NonSerialized] private bool _inited;

    private Dictionary<string, DictionaryItemModel> _dict;

    public DictionaryItemModel Placeholder => _placeholderModel;

    public DictionaryItemModel Get(string title)
    {
        if(!_inited)
        {
            Init();
        }
        _dict.TryGetValue(title, out var model);
        return model;
    }

    private void Init()
    {
        _dict = new Dictionary<string, DictionaryItemModel>();

        foreach (var item in _models)
        {
            _dict.TryAdd(item.Title, item);
        }

        _inited = true;
    }
}
