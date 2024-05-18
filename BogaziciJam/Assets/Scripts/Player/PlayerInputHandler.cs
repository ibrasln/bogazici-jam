using UnityEngine;
using UnityEngine.InputSystem;

namespace Bogazici.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; private set; }
        public float XInput { get; private set; }
        public float YInput { get; private set; }
        public bool DashInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool AttackInput { get; private set; }
        public bool ChangeTimeInput { get; private set; }
        public bool PauseInput { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                MovementInput = Vector2.zero;
                XInput = 0;
                YInput = 0;
            }
            else
            {
                MovementInput = context.ReadValue<Vector2>();
                XInput = MovementInput.x;
                YInput = MovementInput.y;
            }
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                DashInput = true;
            }
            else if (context.canceled)
            {
                DashInput = false;
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                JumpInput = true;
            }
            else if (context.canceled)
            {
                JumpInput = false;
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInput = true;
            }
            else if (context.canceled)
            {
                AttackInput = false;
            }
        }

        public void OnChangeTime(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ChangeTimeInput = true;
            }
            else if (context.canceled)
            {
                ChangeTimeInput = false;
            }
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                PauseInput = true;
            }
            else if (context.canceled)
            {
                PauseInput = false;
            }
        }

        public void UseJumpInput() => JumpInput = false;
        public void UseDashInput() => DashInput = false;
        public void UseAttackInput() => AttackInput = false;
        public void UseChangeTimeInput() => ChangeTimeInput = false;
    }
}
