using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Attack {

    public static Func<Attack, IAttackable, Vector3> DEFAULT_KNOCKBACK_FUNC { get {
            return (Attack attack, IAttackable attackable) => {
                Vector3 attackPos = new Vector3(attack.Position.x, 0, attack.Position.z);
                Vector3 targetPos = new Vector3(attackable.Transform.position.x, 0, attackable.Transform.position.z);
                return (targetPos - attackPos).normalized * attack.Force;
            };
        }
    }

    public IAttacker Attacker { get; private set; }
    public int Damage { get; private set; }
    public float Force { get; private set; }
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }

    public Func<Attack, IAttackable, Vector3> KnockbackFunc { get; private set; }

    public Attack(IAttacker attacker, int damage, float force, Vector3 position, Quaternion rotation) : this(attacker, damage, force, position, rotation, DEFAULT_KNOCKBACK_FUNC) { }

    public Attack(IAttacker attacker, int damage, float force, Vector3 position, Quaternion rotation, Func<Attack, IAttackable, Vector3> getKnockbackVector) {
        Attacker = attacker;
        Damage = damage;
        Force = force;
        Position = position;
        Rotation = rotation;
        KnockbackFunc = getKnockbackVector;
    }

}
