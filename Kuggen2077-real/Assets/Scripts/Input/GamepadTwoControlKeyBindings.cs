using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadTwoControlKeyBindings : ControlKeyBindings {
    
    public override string HoriszontalAxisID {
        get {
            return "Horizontal_Player2";
        }
    }

    public override string VerticalAxisID {
        get {
            return "Vertical_Player2";
        }
    }

    public override string PrimaryAttackAxisID {
        get {
            return "RAxis_Player2";
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
            return "LAxis_Player2";
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
                return Vector3.right * Input.GetAxisRaw("RHorizontal_Player2") + Vector3.forward * -Input.GetAxisRaw("RVertical_Player2");
            };
        }
    }


}
