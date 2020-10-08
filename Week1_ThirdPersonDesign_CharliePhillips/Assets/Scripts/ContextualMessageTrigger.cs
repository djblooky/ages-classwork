using System;
using UnityEngine;

public class ContextualMessageTrigger : MonoBehaviour
{
    public static event Action MessageTriggerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            MessageTriggerEntered?.Invoke();
    }
}
