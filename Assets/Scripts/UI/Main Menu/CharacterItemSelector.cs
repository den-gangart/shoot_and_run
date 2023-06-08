using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Data;
using UnityEngine.UI;

namespace RunShooter.UI
{
    public class CharacterItemSelector : MonoBehaviour
    {
        [SerializeField] private CharacterBodyPartSprites _spritesData;

        [SerializeField] private Button _headButton;
        [SerializeField] private Button _bodyButton;

        [SerializeField] private GameObject _listHeadParent;
        [SerializeField] private GameObject _listBodyParent;

        [SerializeField] private Sprite _buttonHighLightTexture;
        [SerializeField] private Sprite _buttonDimTexture;

        [SerializeField] private StagePart _stagePrefab;

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

            _listHeadParent.SetActive(isHead);
            _listBodyParent.SetActive(!isHead);
        }

        private void InitLists()
        {
            SpawnList(_spritesData.heads, _listHeadParent.transform);
            SpawnList(_spritesData.bodies, _listBodyParent.transform);
        }

        private void SpawnList(List<Sprite> sprites, Transform parent)
        {
            foreach (var sprite in sprites)
            {
                StagePart stagePart = Instantiate(_stagePrefab, parent);
                stagePart.ChildImage.sprite = sprite;
            }
        }
    }
}
