using System;
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
        System.Random rnd = new System.Random((int)(99999 * UnityEngine.Random.value));
        int r = rnd.Next(list.Count);
        return list[r];
    }

	public static string LeftPad(string s, int length, string padChar){
		if (length < s.Length) {
			return s;
		}

		int padLength = length - s.Length;
		while (padLength > 0) {
			s = padChar + s;
			padLength--;
		}

		return s;
	}

	public static GameObject FindChildWithTag(GameObject parent, string tag) {
		Transform t = parent.transform;
	
		foreach(Transform tr in t) {
			if (tr.tag == tag) {
				return tr.gameObject;
			}

			GameObject found = FindChildWithTag (tr.gameObject, tag);
			if (found != null) {
				return found;
			}
		}

		return null;
	}

	public static T FindComponentInChildWithTag<T>(GameObject parent, string tag) where T:Component {
		GameObject res = FindChildWithTag (parent, tag);
		if (res != null) {
			return res.GetComponent<T> ();
		}
		return null;
	}
}
