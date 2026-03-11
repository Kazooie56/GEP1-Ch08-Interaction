using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    // use this bool in the inspector to enable or disable debug messages in the console.
    public bool debugEnabled = false;

    // This holds the Interactable object we are currently in range of.
    // It stays 'null' until we touch something that implements IInteractable.
    private IInteractable targetInteractable;

    [SerializeField] private GameObject debugCurrentInteractable;

    private UIManager uiManager;

    private void Start()
    {
        uiManager = ServiceHub.Instance.UIManager;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable = foundInteractable;
            debugCurrentInteractable = other.gameObject;

            uiManager.ShowPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable = null;
            debugCurrentInteractable = null;

            uiManager.HidePrompt();
        }
    }

    // When Interact input pressed call this
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (debugEnabled) Debug.Log("Attempting to interact");
            
            // if targetInteractable is not empty we can attempt to interact
            if (targetInteractable != null)
            {
                targetInteractable.Interact();

            }
        }
    }
}
