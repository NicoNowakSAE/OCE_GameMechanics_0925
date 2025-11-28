using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public abstract void Interact();
}

public interface IInteractable
{
    public void Interact();
}
