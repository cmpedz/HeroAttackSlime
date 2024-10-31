using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum KeyInAnimationStatusDictionary
{
    Run,
    Idle,
    ChangeMove,
    Jump,
    Hurt,
    Attack
}

public class KeyValueAnimatorController
{
    private static Dictionary<KeyInAnimationStatusDictionary, object> gameDictionary = new Dictionary<KeyInAnimationStatusDictionary, object>() {

        { KeyInAnimationStatusDictionary.Run, 1},

        { KeyInAnimationStatusDictionary.Idle, 0},

        { KeyInAnimationStatusDictionary.ChangeMove, "ChangeMove"},

        { KeyInAnimationStatusDictionary.Jump, 2},

        { KeyInAnimationStatusDictionary.Hurt, "Hurt"},

        { KeyInAnimationStatusDictionary.Attack, "Attack"}
    };


    public static object GetValueFromKeyObject(KeyInAnimationStatusDictionary key) { 

        return gameDictionary[key];

    }

    
}
