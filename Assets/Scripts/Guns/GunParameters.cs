using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    [System.Serializable]
    public class GunParameters
    {
        public int id;
        public GunType gunType;
        public int bulletPerShot;
        public float damage;
        public float coolDown;

        public Texture2D Icon;
        public GameObject Prefab;
    }
}
