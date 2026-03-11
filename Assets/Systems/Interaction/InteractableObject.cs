using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public bool debugEnabled = false;
    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
    public void Focused()
    {

    }
    public void Unfocused()
    {

    }
}
