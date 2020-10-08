using System;
using UnityEngine;

public class ContextualMessageTrigger : MonoBehaviour
{
    [SerializeField]
    private string message = "Default message";

    [SerializeField]
    private float duration = 3;

    public static event Action<string, float> MessageTriggerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            MessageTriggerEntered?.Invoke(message, duration);
    }
}
