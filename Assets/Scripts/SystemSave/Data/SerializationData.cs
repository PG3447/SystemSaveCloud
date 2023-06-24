using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


[Serializable]
public class SerializationData<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver, ISerializable
{
    [SerializeField] private List<TKey> _keys = new List<TKey>();
    [SerializeField] private List<TValue> _values = new List<TValue>();

    //Unity doesn't know how to serialize a Dictionary
    public SerializationData(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public SerializationData() { }

    public void OnBeforeSerialize()
    {
        _keys.Clear();
        _values.Clear();

        foreach (KeyValuePair<TKey,TValue> dictionary in this)
        {
            _keys.Add(dictionary.Key);
            _values.Add(dictionary.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();

        for (int i = 0; i < _keys.Count; i++) 
        {
            this.Add(_keys[i], _values[i]);
        }
    }
}
