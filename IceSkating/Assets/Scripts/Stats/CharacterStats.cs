using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats", order = 1)]
public class CharacterStats : ScriptableObject
{
    public float speed;
    public float rotationSpeed;
}
