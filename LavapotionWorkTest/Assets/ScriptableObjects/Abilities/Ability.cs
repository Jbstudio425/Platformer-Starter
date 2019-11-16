using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public virtual void Initialize(CharacterBase character){}
    public abstract void Act(CharacterBase character);
}
