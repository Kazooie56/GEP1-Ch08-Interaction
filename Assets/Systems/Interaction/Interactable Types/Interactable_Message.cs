using UnityEngine;

public class Interactable_Message : MonoBehaviour, IInteractable
{
    [Header("Message")]
    [SerializeField] private string message;

    private UIManager uiManager;

    private void Start()
    {
        uiManager = ServiceHub.Instance.UIManager;

        if (uiManager == null) Debug.LogError("UIManager not found in ServiceHub. Please ensure it is properly set up.");
    }

    public void Interact()
    {
        uiManager.DisplayMessage(message);
    }
    public void Focused()
    {
        
    }
    public void Unfocused()
    {

    }
}
