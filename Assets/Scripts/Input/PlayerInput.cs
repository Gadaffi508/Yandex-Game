using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ducktastic
{
    public class PlayerInput : MonoBehaviour, InputManager.IKeyboardActions
    {
        public Vector2 MoveEvent;
        
        public Vector2 MouseEvent;
        
        private InputManager _manager;

        void Start()
        {
            if (_manager == null)
            {
                _manager = new InputManager();
                
                _manager.Keyboard.SetCallbacks(this);

                SetGamePlay();
            }
        }

        void SetGamePlay()
        {
            _manager.Keyboard.Enable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            
        }

        public void OnMouse(InputAction.CallbackContext context)
        {
            
        }
    }
}
