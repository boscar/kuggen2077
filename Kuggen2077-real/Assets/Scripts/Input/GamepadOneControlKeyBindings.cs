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

    public override string PrimaryAttackAxisID {
        get {
            return "RAxis";
        }
    }

    public override KeyCode PrimaryAttack
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public override string PrimaryAbilityAxisID
    {
        get
        {
            return "LAxis";
        }
    }

    public override KeyCode PrimaryAbility
    {
        get
        {
            throw new NotImplementedException();
        }
    }




    public override Func<Transform, Vector3> GetDirection {
        get {
            return (transform) => {
                return Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
            };
        }
    }


}
