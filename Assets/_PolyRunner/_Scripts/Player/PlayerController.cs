using UnityEngine;

namespace PolyRunner
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _characterController;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (Time.deltaTime == 0) { return; }
            Vector2 value = new(PlayerInputs.Actions.Player.Horizontal.ReadValue<float>(), 0f);
            _characterController.Move(value / 30f);
        }
    }
}
