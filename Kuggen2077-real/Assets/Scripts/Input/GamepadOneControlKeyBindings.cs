using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadOneControlKeyBindings : ControlKeyBindings {
    
    public override string HoriszontalAxisID {
        get {
            return "Horizontal";
        }
    }

    public override string VerticalAxisID {
        get {
            return "Vertical";
        }
    }

    public override KeyCode PrimaryAttack {
        get {
            return KeyCode.Joystick1Button9;
        }
    }

    public override KeyCode PrimaryAbility {
        get {
            return KeyCode.Joystick1Button5;
        }
    }

    public override Func<Transform, Vector3> GetDirection {
        get {
            return (transform) => {
                Vector3 direction = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
                
                if(direction.sqrMagnitude > 0.0f)
                {
                    transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
                    return direction;
                } else {
                    return transform.localRotation.eulerAngles;
                }
            };
        }
    }
}
