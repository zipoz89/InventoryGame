using _Scripts._InputSystem;
using _Scripts._Items;
using UnityEngine;

namespace _Scripts._Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float interactionDistance = 5f;
        private InputProvider _inputProvider;
        private PlayerInventory _playerInventory;
        private IInteractable activeInteracable;

        public void Initialize(InputProvider input, PlayerInventory playerInventory)
        {
            _inputProvider = input;
            _playerInventory = playerInventory;
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

        public bool TryCollcetItem(Item item1)
        {
            return _playerInventory.TryCollectItem(item1);
        }
    }
}