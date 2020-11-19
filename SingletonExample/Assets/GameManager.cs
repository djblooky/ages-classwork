using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("the game manager is null");

            return _instance;
        }
    }

    private static GameManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void DisplayName()
    {
        Debug.Log("name");
    }
}
