﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable {

    float MovementSpeed { get; set; }

    float MovementFloatiness { get; set; }

    MovementHandler MovementHandler { get; set; }

    Rigidbody Rigidbody { get; set; }

}