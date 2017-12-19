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

    public static T GetRandom<T> (IList<T> list) {
        System.Random rnd = new System.Random();
        int r = rnd.Next(list.Count);
        return list[r];
    }

}
