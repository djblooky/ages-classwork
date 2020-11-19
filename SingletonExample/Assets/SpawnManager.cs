using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("the Spawn manager is null");

            return _instance;
        }
    }

    private static SpawnManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void StartSpawning()
    {
        Debug.Log("Spawn started");
    }
}
