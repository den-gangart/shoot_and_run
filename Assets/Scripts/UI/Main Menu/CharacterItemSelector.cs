using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Data;
using UnityEngine.UI;

namespace RunShooter.UI
{
    public class CharacterItemSelector : MonoBehaviour
    {
        [SerializeField] private Button _headButton;
        [SerializeField] private Button _bodyButton;

        [SerializeField] private Transform _listHeadParent;
        [SerializeField] private Transform _listBodyParent;

        [SerializeField] private Sprite _buttonHighLightTexture;
        [SerializeField] private Sprite _buttonDimTexture;

        [SerializeField] private StagePart _stagePrefab;
        [SerializeField] private BodyPartData _bodyPartData;

        private void Start()
        {
            _headButton.onClick.AddListener(OnSelectHeadList);
            _bodyButton.onClick.AddListener(OnSelectBodyList);
            InitLists();
            OnSelectHeadList();
        }

        private void OnSelectHeadList()
        {
            SelectList(true);
        }

        private void OnSelectBodyList()
        {
            SelectList(false);
        }

        private void SelectList(bool isHead)
        {
            _headButton.GetComponent<Image>().sprite = isHead ? _buttonHighLightTexture : _buttonDimTexture;
            _bodyButton.GetComponent<Image>().sprite = !isHead ? _buttonHighLightTexture : _buttonDimTexture;

            _listHeadParent.gameObject.SetActive(isHead);
            _listBodyParent.gameObject.SetActive(!isHead);
        }

        private void InitLists()
        {
            SpawnList(_bodyPartData.heads, _listHeadParent);
            SpawnList(_bodyPartData.bodies, _listBodyParent);
        }

        private void SpawnList(List<Sprite> sprites, Transform parent)
        {
            for(int i = 0; i < sprites.Count; i++)
            {
                StagePart stagePart = Instantiate(_stagePrefab, parent);
                stagePart.Index = i;
                stagePart.OnStageSelected += parent == _listHeadParent ? OnHeadSelected : OnBodySelected;
                stagePart.ChildImage.sprite = sprites[i];
            }
        }

        private void OnHeadSelected(int index)
        {
            _bodyPartData.Value.selectedHeadIndex = index;
            _bodyPartData.UpdateData();
        }

        private void OnBodySelected(int index)
        {
            _bodyPartData.Value.selectedBodyIndex = index;
            _bodyPartData.UpdateData();
        }
    }
}
