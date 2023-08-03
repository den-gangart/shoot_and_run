using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;
using System.Threading.Tasks;
using System.IO;

namespace RunShooter.Data
{
    public class AssetDataLoader
    {
        public static async Task<T> LoadInstanceAsync<T>(string path)
        {
            var operation = Addressables.InstantiateAsync(path);
            return GetGameObjectComponent<T>(await operation.Task);
        }

        public static async Task<T> LoadAssetPrefabWithComponent<T>(string path)
        {
            GameObject prefab = await LoadAssetAsync<GameObject>(path);
            return GetGameObjectComponent<T>(prefab);
        }

        public static async Task<T> LoadAssetPrefabWithComponent<T>(AssetReference assetReference)
        {
            GameObject prefab = await LoadAssetAsync<GameObject>(assetReference);
            return GetGameObjectComponent<T>(prefab);
        }

        public static async Task<T> LoadAssetAsync<T>(string path)
        {
            var operation = Addressables.LoadAssetAsync<T>(path);
            return await operation.Task;      
        }

        public static async Task<T> LoadAssetAsync<T>(AssetReference assetReference)
        {
            var operation = Addressables.LoadAssetAsync<T>(assetReference);
            return await operation.Task;
        }

        private static T GetGameObjectComponent<T>(GameObject go)
        {
            if (go.TryGetComponent(out T component))
            {
                return component;
            }

            throw new TypeLoadException("Invalid prefab component");
        }
    }
}
