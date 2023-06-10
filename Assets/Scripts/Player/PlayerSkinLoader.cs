using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Data;

namespace RunShooter.Player
{
    public class PlayerSkinLoader : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _headObjectList;
        [SerializeField] private List<GameObject> _bodyObjectList;
        [SerializeField] private BodyPartData _bodyPartData;

        private GameObject _currentHead;
        private GameObject _currentBody;

        private void OnEnable()
        {
            _bodyPartData.Changed += UpdateSkin;
            UpdateSkin(_bodyPartData.Value);
        }

        private void OnDisable()
        {
            _bodyPartData.Changed -= UpdateSkin;
        }

        private void UpdateSkin(ItemsInfo itemsInfo)
        {
            SetItemsActive(false);

            _currentBody = _headObjectList[itemsInfo.selectedHeadIndex];
            _currentHead = _bodyObjectList[itemsInfo.selectedBodyIndex];

            SetItemsActive(true);
        }

        private void SetItemsActive(bool active)
        {
            _currentBody?.SetActive(active);
            _currentHead?.SetActive(active);
        }
    }
}
