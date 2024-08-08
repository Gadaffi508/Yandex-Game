using System;
using UnityEngine;

namespace Ducktastic
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action<bool> OnSprint;
        
        public event Action<bool> OnFire;
        
        internal Vector2 CurrentMovement;
        
        internal Vector2 MouseMovement;

        internal bool FireClick;

        internal bool SprintClick;
        
        private InputManager _ınputManager;

        public InputManager InputManager
        {
            get
            {
                if (_ınputManager == null)
                {
                    _ınputManager = new InputManager();
                }

                return _ınputManager;
            }
        }

        private void Awake()
        {
            InputManager.Keyboard.Move.performed += ctx => CurrentMovement = ctx.ReadValue<Vector2>();
            
            InputManager.Keyboard.Mouse.performed += ctx => MouseMovement = ctx.ReadValue<Vector2>();
            
            InputManager.Keyboard.Fire.performed += ctx =>
            {
                FireClick = ctx.ReadValueAsButton();
                OnFire?.Invoke(FireClick);
            };
            
            InputManager.Keyboard.Sprint.performed += ctx =>
            {
                SprintClick = ctx.ReadValueAsButton();
                OnSprint?.Invoke(SprintClick);
            };
        }
        
        private void OnEnable() =>
            
            InputManager.Keyboard.Enable();

        private void OnDisable() =>
            
            InputManager.Keyboard.Disable();
    }
}
