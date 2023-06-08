using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Data
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/PlayerData_ScriptableObject")]
    public class PlayerData : ScriptableObject
    {
        public SavableData Value => _data;

        [SerializeField] private SavableData _data;
        [SerializeField] private string _jsonString;
        
        private const string DATA_KEY = "data";

        private void Awake()
        {
            Load();
        }

        private void OnDestroy()
        {
            Save();
        }

        private void Save()
        {
            _jsonString = JsonUtility.ToJson(_data);
            PlayerPrefs.SetString(DATA_KEY, _jsonString);
            PlayerPrefs.Save();
        }

        private void Load()
        {
            _jsonString= PlayerPrefs.GetString(DATA_KEY, "");
            
            if(string.IsNullOrEmpty(_jsonString))
            {
                SetInitialData();
                return;
            }

            _data = JsonUtility.FromJson<SavableData>(_jsonString);
        }

        private void SetInitialData()
        {
            _data = new SavableData();
        }

        private void OnValidate()
        {
            _jsonString = JsonUtility.ToJson(_data);
        }
    }
}
