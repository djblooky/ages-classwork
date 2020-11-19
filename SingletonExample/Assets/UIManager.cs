using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("the UI manager is null");

            return _instance;
        }
    }

    private static UIManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateScore(int score)
    {
        Debug.Log("Score: " + score);
        Debug.Log("Notifying the game manager");
        GameManager.Instance.DisplayName(); // managers can call other managers, but they can't call non-managers
    }
}
