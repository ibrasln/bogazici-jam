using UnityEngine;
using UnityEngine.InputSystem;

namespace Bogazici.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; private set; }
        public int XInput { get; private set; }
        public int YInput { get; private set; }
        public bool RollInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool AttackInput { get; private set; }

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
                XInput = (int)MovementInput.x;
                YInput = (int)MovementInput.y;
            }
        }

        public void OnRoll(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                RollInput = true;
            }
            else if (context.canceled)
            {
                RollInput = false;
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

        public void UseJumpInput() => JumpInput = false;
        public void UseRollInput() => RollInput = false;
        public void UseAttackInput() => AttackInput = false;
    }
}
