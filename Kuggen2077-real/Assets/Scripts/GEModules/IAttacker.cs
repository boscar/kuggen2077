using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker {

    Dictionary<string, Attack> Attacks { get; }

}
