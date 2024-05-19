using UnityEngine;
using UnityEngine.InputSystem;

namespace Bogazici.SamuraiBoss
{
    public class SamuraiBossInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; private set; }
        public float XInput { get; private set; }
        public float YInput { get; private set; }
        public bool MidAttackInput { get; private set; }
        public bool LowAttackInput { get; private set; }
        public bool OverHeadAttackInput { get; private set; }
        public bool SpecialInput { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                MovementInput = Vector2.zero;
                XInput = 0f;
                YInput = 0f;
            }
            else
            {
                MovementInput = context.ReadValue<Vector2>();
                XInput = MovementInput.x;
                YInput = MovementInput.y;
            }
        }

        public void OnMidAttack(InputAction.CallbackContext context)
        {
            if (context.started)
                MidAttackInput = true;
            else if (context.canceled)
                MidAttackInput = false;
        }
        public void OnLowAttack(InputAction.CallbackContext context)
        {
            if (context.started)
                LowAttackInput = true;
            else if (context.canceled)
                LowAttackInput = false;
        }
        public void OnOverHeadAttack(InputAction.CallbackContext context)
        {
            if (context.started)
                OverHeadAttackInput = true;
            else if (context.canceled)
                OverHeadAttackInput = false;
        }
        public void OnSpecial(InputAction.CallbackContext context)
        {
            if (context.started)
                SpecialInput = true;
            else if (context.canceled)
                SpecialInput = false;
        }

        public void UseMidAttackInput()
        {
            MidAttackInput = false;
        }
        public void UseLowAttackInput()
        {
            LowAttackInput = false;
        }
        public void UseOverHeadAttackInput()
        {
            OverHeadAttackInput = false;
        }
        public void UseSpecialInput()
        {
            SpecialInput = false;
        }
    }
}
