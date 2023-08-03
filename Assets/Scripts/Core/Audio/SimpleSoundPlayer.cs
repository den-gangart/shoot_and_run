using UnityEngine;

namespace RunShooter
{
    public class SimpleSoundPlayer : MonoBehaviour
    {
        public void PlayGameSound(string soundName)
        {
            AudioHandler.Instance.PlayGameSound(soundName, gameObject);
        }
    }
}