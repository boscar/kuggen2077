using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentDictionary {
    
    private static Dictionary<int, GameEntity> ENTITY_DICTIONARY = new Dictionary<int, GameEntity>();

    public static GameEntity GetEntity(Component component) {
        return GetComponent<GameEntity>(component, ENTITY_DICTIONARY);
    }

    private static T GetComponent<T>(Component component, Dictionary<int, T> dictionary) {
        int hashCode = component.GetHashCode();
        if (dictionary.ContainsKey(hashCode)) {
            return dictionary[hashCode];
        } else {
            T obj = component.GetComponent<T>();
            dictionary.Add(hashCode, obj);
            return obj;
        }
    }

    public static void RemoveComponents(Component component) {
        int hashCode = component.GetHashCode();
        ENTITY_DICTIONARY.Remove(hashCode);
    }

}
