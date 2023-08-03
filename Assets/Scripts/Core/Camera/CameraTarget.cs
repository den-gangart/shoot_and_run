using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Player
{
    public class CameraTarget : MonoBehaviour
    {
        private void Start()
        {
            Camera.main.GetComponent<CameraFollow>().SetTarget(this);
        }
    }
}
