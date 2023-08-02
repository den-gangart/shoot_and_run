using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    public interface IEventListener
    {
        public void OnEventRecivied(BaseEvent baseEvent);
    }
}
