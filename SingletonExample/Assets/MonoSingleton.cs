using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    public static T Instance 
    {
        get
        {
            if (_instance == null)
                Debug.Log(typeof(T).ToString() + " is null");

            return _instance;
        }
    }

    private static T _instance;

    private void Awake()
    {
        _instance = this as T;

        Init();
    }

    public virtual void Init() 
    { 
     //optional to override
    }
}
