using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public class GunSelector : MonoBehaviour
    {
        public BaseGun Current { get; private set; }
        [SerializeField] private int _defaultId;
        [SerializeField] private List<BaseGun> _gunList;

        private void Awake()
        {
            SelectGun(_defaultId);
        }

        public BaseGun SelectGun(int id)
        {
            if (Current != null)
            {
                Current.gameObject.SetActive(false);
            }

            Current = _gunList.Find(gun => gun.Id == id);
            Current.gameObject.SetActive(true);
            return Current;
        }
    }
}
