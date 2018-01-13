using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section {

    public List<Event> Events { get; set; }
    public bool IsFinished { get; set; }
    public int Index { get; private set; }

    public Section (int index) {
        Index = index;
        Events = new List<Event>();
    }
}
