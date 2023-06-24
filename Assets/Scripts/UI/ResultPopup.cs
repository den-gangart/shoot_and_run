using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RunShooter.UI
{
    public class ResultPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private TextMeshProUGUI _killCountText;

        public void Initialize(int killCount, string time)
        {
            _killCountText.text = killCount.ToString();
            _timeText.text = time.ToString();
        }
    }
}
