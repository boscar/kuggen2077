using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudible {

	AudioSource AudioSource { get; set; }

	AudioHandler AudioHandler { get; }

}
