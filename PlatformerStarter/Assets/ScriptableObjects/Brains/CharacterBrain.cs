using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBrain : ScriptableObject
{
    public virtual void Initialize(CharacterBase character){}
    public abstract void Think(CharacterBase character);
}
