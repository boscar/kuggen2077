using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ControlKeyBindings {

    public enum ControlScheme { KEYBOARD, GAMEPAD0, GAMEPAD1 };

    public abstract string VerticalAxisID { get; }
    public abstract string HoriszontalAxisID { get; }

    public abstract KeyCode PrimaryAttack { get; }
    public abstract KeyCode PrimaryAbility { get; }

    public abstract string PrimaryAttackAxisID { get; }
    public abstract string PrimaryAbilityAxisID { get; }

    public abstract Func<Transform, Vector3> GetDirection { get; }

	public abstract string Confirm { get; }
	public abstract string Discard { get; }

}
