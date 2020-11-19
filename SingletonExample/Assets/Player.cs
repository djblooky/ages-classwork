using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameManager.Instance.DisplayName();
        UIManager.Instance.UpdateScore(10);
        SpawnManager.Instance.StartSpawning();
    }

}
