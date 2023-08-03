using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Data
{
    public class MonoEntity : MonoBehaviour
    {
        private List<IDisposable> _childEntityList = new List<IDisposable>();

        protected void RegisterChild(IDisposable child)
        {
            _childEntityList.Add(child);
        }

        private void OnDestroy()
        {
            for (int i = _childEntityList.Count - 1; i >= 0; i--)
            {
                _childEntityList[i].Dispose();
            }
        }
    }
}
