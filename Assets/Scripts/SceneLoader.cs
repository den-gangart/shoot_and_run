using RunShooter.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunShooter
{
    public enum SceneIndex
    {
        MainMenu = 0,
        GameField = 1,
    }

    [RequireComponent(typeof(LoadScreen))]
    public class SceneLoader : Singleton<SceneLoader>
    {
        private LoadScreen _loadScreen;
        private const float LOAD_DELAY = 0.5f;

        private void Start()
        {
            _loadScreen = GetComponent<LoadScreen>();
            _loadScreen.Show();
        }

        public void LoadScene(SceneIndex sceneIndex)
        {
            StartCoroutine(LoadSceneRoutine((int)sceneIndex));
        }

        public IEnumerator LoadSceneRoutine(int sceneIndex)
        {
            _loadScreen.Show();

            yield return new WaitForSeconds(LOAD_DELAY);

            SceneManager.LoadSceneAsync((int)sceneIndex);
        }
    }
}
