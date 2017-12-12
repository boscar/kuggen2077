using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker {

    Dictionary<string, AttackAction> AttackActions { get; }

}
