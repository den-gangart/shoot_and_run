using RunShooter.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Data
{
    public class ScriptableObjectDataSaver<T> : ScriptableObject where T : new()
    {
        public T Value => _data;
        public event Action<T> Changed;
        protected virtual string DATA_KEY { get; }

        [SerializeField] private T _data;
        [SerializeField] private string _jsonString;

        private void Awake()
        {
            Load();
        }

        private void OnDestroy()
        {
            Save();
        }

        public void UpdateData()
        {
            Changed?.Invoke(_data);
            OnDataUpdated();
            Save();
        }

        protected virtual void OnDataUpdated() { }

        private void Save()
        {
            _jsonString = JsonUtility.ToJson(_data);
            PlayerPrefs.SetString(DATA_KEY, _jsonString);
            PlayerPrefs.Save();
        }

        private void Load()
        {
            _jsonString = PlayerPrefs.GetString(DATA_KEY, "");

            if (string.IsNullOrEmpty(_jsonString))
            {
                SetInitialData();
                return;
            }

            _data = JsonUtility.FromJson<T>(_jsonString);
        }

        private void SetInitialData()
        {
            _data = new T();
        }

        private void OnValidate()
        {
            _jsonString = JsonUtility.ToJson(_data);
        }
    }
}
