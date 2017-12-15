﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable {

    int HitPoints { get; set; }
    int CurrentHitPoints { get; set; }

    Transform Transform { get; }

    RecieveAttackHandler RecieveAttackHandler { get; }

}