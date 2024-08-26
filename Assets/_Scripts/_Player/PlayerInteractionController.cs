using UnityEngine;

namespace _Scripts._Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float interactionDistance = 5f;
        private InputProvider _inputProvider;
        private IInteractable activeInteracable;

        public void Initialize(InputProvider input)
        {
            _inputProvider = input;
            _inputProvider.OnInteract += Interact;
        }

        private void Interact(bool pressed)
        {
            if (pressed && activeInteracable != null)
            {
                activeInteracable.Interact(this);
            }
        }

        public void CustomUpdate()
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Vector3.zero);
        
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactionDistance)) {

                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    activeInteracable = interactable;
                }
            }
            else
            {
                activeInteracable = null;
            }
        }

        public void CollcetItem()
        {
            Debug.Log("Collect");
        }
    }
}