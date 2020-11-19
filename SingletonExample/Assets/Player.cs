using UnityEngine;

public class Player : MonoSingleton<Player>
{
    private void Start()
    {
        GameManager.Instance.DisplayName();
        SpawnManager.Instance.StartSpawning();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.UpdateScore(10);
        }
    }

    public override void Init()
    {
        base.Init();
        Debug.Log("Player initialized!");
        LevelManager.Instance.LoadLevel();
    }

}
