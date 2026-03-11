using UnityEngine;

public class Interactable_Pickup : MonoBehaviour, IInteractable
{
    // Use this bool in the inspector
    private bool debugEnabled = false;

    public void Interact()
    {
        if (debugEnabled) Debug.Log("Attempting to interact");

        // add logic to add item to inventory

        Destroy(gameObject);
    }

    public void Focused()
    {
        
    }

    public void Unfocused()
    {

    }
}
