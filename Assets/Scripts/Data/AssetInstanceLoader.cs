using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace RunShooter.Data
{
    public class AssetInstanceLoader
    {
        private AsyncOperationHandle<GameObject> _operationHandle;
        private GameObject _cashedAsset;

        public AssetInstanceLoader() {}

        public async Task<T> GetInstanceAsync<T>(string path)
        {
            if(_cashedAsset == null)
            {
                _operationHandle = Addressables.LoadAssetAsync<GameObject>(path);
                _cashedAsset = await _operationHandle.Task;
            }

            return InstantiateAndGetComponent<T>();
        }

        public async Task<T> GetInstanceAsync<T>(AssetReference assetReference)
        {
            if (_cashedAsset == null)
            {
                _operationHandle = Addressables.LoadAssetAsync<GameObject>(assetReference);
                _cashedAsset = await _operationHandle.Task;
            }

            return InstantiateAndGetComponent<T>();
        }

        public void Release()
        {
            Addressables.Release(_operationHandle);
        }

        private T InstantiateAndGetComponent<T>()
        {
            var go = UnityEngine.Object.Instantiate(_cashedAsset);

            if (go.TryGetComponent(out T component))
            {
                return component;
            }

            throw new TypeLoadException("Invalid prefab component");
        }
    }
}
