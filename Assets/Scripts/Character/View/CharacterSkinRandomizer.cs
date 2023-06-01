using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    public class CharacterSkinRandomizer: MonoBehaviour
    {
        [SerializeField] private GameObject _currentHead;
        [SerializeField] private GameObject _currentBody;
        [SerializeField] private List<GameObject> _headList = new List<GameObject>();
        [SerializeField] private List<GameObject> _bodyList = new List<GameObject>();

        private void Start()
        {
            Randomize();
        }

        public void Randomize()
        {
            _currentHead?.SetActive(false);
            _currentBody?.SetActive(false);

            _currentHead = _headList[Random.Range(0, _headList.Count)];
            _currentBody = _bodyList[Random.Range(0, _bodyList.Count)];

            _currentHead.SetActive(true);
            _currentBody.SetActive(true);
        }
    }
}
