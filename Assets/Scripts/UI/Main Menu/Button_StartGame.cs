using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.UI
{
    public class Button_StartGame : MonoBehaviour
    {
        public void StartGame()
        {
            SceneLoader.Instance.LoadScene(SceneIndex.GameField);
        }
    }
}
