using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="LevelLayouts/Level")]
public class LevelLayout : ScriptableObject
{
    public Vector2[] enemyPositions;
    public Vector2[] coinPositions;
    public Vector2 startPosition;
}
