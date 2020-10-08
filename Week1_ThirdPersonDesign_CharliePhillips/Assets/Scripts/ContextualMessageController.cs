using System.Collections;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private TMP_Text messageText;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();
        canvasGroup.alpha = 0;
    }

    private IEnumerator ShowMessage(string message, float messageDuration)
    {
        canvasGroup.alpha = 1;
        messageText.text = message;
        yield return new WaitForSeconds(messageDuration);
        canvasGroup.alpha = 0;
    }

    private void OnMessageTriggerEntered(string message, float messageDuration)
    {
        StartCoroutine(ShowMessage(message, messageDuration));
    }

    private void OnEnable()
    {
        ContextualMessageTrigger.MessageTriggerEntered += OnMessageTriggerEntered;
    }

    private void OnDisable()
    {
        ContextualMessageTrigger.MessageTriggerEntered -= OnMessageTriggerEntered;
    }

}
