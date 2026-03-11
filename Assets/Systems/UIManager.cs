using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
{
    [SerializeField] bool debugEnabled = false;

    [Header("Interact Prompt")]
    [SerializeField] private TMP_Text promptText;
    [SerializeField] private string prompt;



    [Header("Interact Message")]
    [SerializeField] float messageDuration = 3.0f;
    [SerializeField] float fadeOutTime = 0.5f;




    [SerializeField] private TMP_Text messageText;
    private string currentMessage = "";

    private Coroutine fadeCoroutine;
    private void Start()
    {
        currentMessage = "";
    }

    public void DisplayMessage(string message)
    {
        //currentMessage = message;
        if(fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(DisplayMessageAndFade(message));

        if (debugEnabled) Debug.Log("UIManager: Display Message called");

    }

    public void ShowPrompt()
    {
        promptText.text = prompt;
    }

    public void HidePrompt()
    {
        promptText.text = "";
    }

    private IEnumerator DisplayMessageAndFade(string message)
    {
        messageText.text = message;
        messageText.alpha = 1f;

        float elapsedTime = 0f;

        yield return new WaitForSeconds(messageDuration); // wait before fading out

        Color OriginalColor = messageText.color;

        while (elapsedTime < messageDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);

            messageText.alpha = alpha;

            yield return null;
        }

        messageText.text = "";

        //messageText.text = message;

        //yield return new WaitForSeconds(3f);

        //// Pass message through the UI manager to the Text display
        //messageText.text = "this is an override";
    }
}
