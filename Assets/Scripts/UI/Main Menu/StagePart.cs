using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunShooter.UI
{
    public class StagePart : MonoBehaviour
    {
        public event Action<int> OnStageSelected;
        public Image ChildImage => _childImage;
        public int Index  { get => _index; set => _index = value; }

        [SerializeField] private Image _childImage;
        private int _index;

        public void SelectStage()
        {
            OnStageSelected?.Invoke(_index);
        }
    }
}
