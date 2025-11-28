using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        transform.localScale *= 2;
    }

    
}
