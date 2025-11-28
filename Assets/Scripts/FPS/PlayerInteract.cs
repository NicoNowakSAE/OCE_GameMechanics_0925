using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float raycastRange = 5;

    [SerializeField]
    private LayerMask hittableLayers;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            bool result = Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, raycastRange, hittableLayers);

            Color col = Color.red;
            if(result)
            {
                col = Color.green;

                IInteractable io = hit.collider.gameObject.GetComponent<IInteractable>();

                if (io != null)
                {
                    io.Interact();
                }
            }
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * raycastRange, col, 4);

            
        }
    }

}
