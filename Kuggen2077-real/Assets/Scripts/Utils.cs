using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {

    public static bool Contains(IEnumerable<string> collection, string value) {
        foreach(string s in collection) {
            if(s.Equals(value)) {
                return true;
            }
        }
        return false;
    }

}
