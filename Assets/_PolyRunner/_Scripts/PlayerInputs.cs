using UnityEngine;

namespace PolyRunner
{
    public class PlayerInputs : MonoBehaviour
    { 
        public static InputActions Actions { get; private set; }

        private void OnEnable()
        {
            Actions = new InputActions();
            Actions.Enable();
        }

        private void OnDisable()
        {
            Actions.Disable();
        }
    }
}
