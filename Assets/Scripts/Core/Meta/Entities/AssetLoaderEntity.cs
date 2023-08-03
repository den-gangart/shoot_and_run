using RunShooter.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace RunShooter.Data
{
    public class AssetLoaderEntity: DisposableEntity
    {
        private AssetInstanceLoader _loader;

        protected async Task<T> InstantiateAsset<T>(string path)
        {
            _loader = new AssetInstanceLoader();
            return await _loader.GetInstanceAsync<T>(path);
        }

        public override void Dispose()
        {
            _loader.Release();
            base.Dispose();
        }
    }
}
