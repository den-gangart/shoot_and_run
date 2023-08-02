using RunShooter.GameProccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace RunShooter.Data
{
    public class MapEntity : AssetLoaderEntity
    {
        public Map Map { get; private set; }

        public async Task Init()
        {
            Map = await InstantiateAsset<Map>(GameFieldAssetPathData.MAP_ADRESS);
        }
    }
}
