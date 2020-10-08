using System.Collections;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
    [SerializeField]
    private float delayBeforehidingText = 3;

    private CanvasGroup canvasGroup;
    private TMP_Text messageText;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();
        canvasGroup.alpha = 0;
    }

    private IEnumerator ShowMessage(string message)
    {
        canvasGroup.alpha = 1;
        messageText.text = message;
        yield return new WaitForSeconds(delayBeforehidingText);
        canvasGroup.alpha = 0;
    }

    private void OnMessageTriggerEntered()
    {
        StartCoroutine(ShowMessage("Trigger entered!"));
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
