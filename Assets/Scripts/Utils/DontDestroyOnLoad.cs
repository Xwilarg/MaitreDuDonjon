using UnityEngine;

namespace DungeonDraws.Scripts.Utils
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}