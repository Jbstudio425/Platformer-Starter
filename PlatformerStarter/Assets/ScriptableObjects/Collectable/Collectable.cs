using UnityEngine;

public abstract class Collectable : ScriptableObject
{
    public virtual void Initialize(GameObject collector){}
    public abstract void Collect(GameObject collector);
}

