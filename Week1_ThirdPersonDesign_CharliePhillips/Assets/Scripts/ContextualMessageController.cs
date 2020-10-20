using System.Collections;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
    [SerializeField]
    private float fadeOutDuration = 1;

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
        //wait for duration
        yield return new WaitForSeconds(messageDuration);
        //start fading out
        float fadeElapsedTime = 0;
        float fadeStartTime = Time.time;
        while (fadeElapsedTime < fadeOutDuration)
        {
            fadeElapsedTime = Time.time - fadeStartTime; //use Time.time in coroutine 
            canvasGroup.alpha = 1 - fadeElapsedTime / fadeOutDuration;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }

    private void OnMessageTriggerEntered(string message, float messageDuration)
    {
        StopAllCoroutines();
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
