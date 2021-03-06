﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControlKeyBindings : ControlKeyBindings
{

    public override string HoriszontalAxisID
    {
        get
        {
            return "Horizontal_Keyboard";
        }
    }

    public override string VerticalAxisID
    {
        get
        {
            return "Vertical_Keyboard";
        }
    }

    public override KeyCode PrimaryAttack
    {
        get
        {
            return KeyCode.Mouse0;
        }
    }

    public override KeyCode PrimaryAbility
    {
        get
        {
            return KeyCode.Space;
        }
    }

    public override Func<Transform, Vector3> GetDirection
    {
        get
        {
            return (transform) =>
            {
                Vector3 direction = transform.rotation.eulerAngles;
                Ray cameraRay = MainCamera.Instance.Camera.ScreenPointToRay(Input.mousePosition);
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                float rayLength;

                if (groundPlane.Raycast(cameraRay, out rayLength))
                {
                    Vector3 pointToLook = cameraRay.GetPoint(rayLength);

                    direction = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);
                }
                return direction;
            };
        }
    }

    public override string PrimaryAttackAxisID
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
            throw new NotImplementedException();
        }
    }

	public override string Confirm {
		get {
			throw new NotImplementedException ();
		}
	}

	public override string Discard {
		get {
			throw new NotImplementedException ();
		}
	}

	public override string Start {
		get {
			throw new NotImplementedException ();
		}
	}
}
