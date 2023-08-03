using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RunShooter
{
    public class DisposableEntity : IDisposable
    {
        private List<IDisposable> _childEntityList = new List<IDisposable>();

        protected void RegisterChild(IDisposable child)
        {
            _childEntityList.Add(child);
        }

        public virtual void Dispose()
        {
            for(int i = _childEntityList.Count - 1; i >= 0; i--)
            {
                _childEntityList[i].Dispose();
            }
        }
    }
}
