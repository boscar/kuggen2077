using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatStat : MonoBehaviour {

    public float Base { get; private set; }

    private Dictionary<string, float> Multipliers = new Dictionary<string, float>();

    public FloatStat(float baseStat) {
        Base = baseStat;
    }

    public void AddMultiplier(string id, float value) {
        if (!Multipliers.ContainsKey(id)) {
            Multipliers.Add(id, value);
        }
    }

    public void RemoveMultiplier(string id) {
        Multipliers.Remove(id);
        if (!Multipliers.ContainsKey(id)) {
            Multipliers.Remove(id);
        }
    }

    public void UpdateMultiplier(string id, float value) {
        if (!Multipliers.ContainsKey(id)) {
            Multipliers[id] = value;
        }
    }

    public float Value () {
        return Base * AvarageMultiplier();
    }

    private float AvarageMultiplier () {
        float val = 0;
        foreach (KeyValuePair<string, float> entry in Multipliers) {
            val += entry.Value;
        }
        val /= Multipliers.Count;
        return val;
    }

}
