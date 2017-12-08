using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControllKeyBindings : ControllKeyBindings {
    
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


    public override KeyCode PrimaryAbility {
        get {
            return KeyCode.Space;
        }
    }
}
