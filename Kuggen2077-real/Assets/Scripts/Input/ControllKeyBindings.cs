using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllKeyBindings {

    public enum ControllScheme { KEYBOARD, GAMEPAD0, GAMEPAD1 };

    public abstract string VerticalAxisID { get; }
    public abstract string HoriszontalAxisID { get; }

    public abstract KeyCode PrimaryAbility { get; }

}
