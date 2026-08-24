using UnityEngine;

namespace GameDev.UnityCommon
{
    /// <summary>
    /// Generic MonoBehaviour singleton base. Not persisted across scenes by
    /// default -- call DontDestroyOnLoad yourself in a subclass if a
    /// particular singleton needs that.
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<T>();
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = (T)this;
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}
