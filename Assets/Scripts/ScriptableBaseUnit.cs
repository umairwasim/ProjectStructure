using System;
using UnityEngine;

[CreateAssetMenu(fileName ="Base Unit", menuName ="Units")]
public class ScriptableBaseUnit : ScriptableObject
{
    public Faction Faction;

    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;

    // Used in menus
    public string Description;
    public Sprite MenuSprite;
}

/// <summary>
/// Keeping base stats as a struct on the scriptable keeps it flexible and easily editable.
/// We can pass this struct to the spawned prefab unit and alter them depending on conditions.
/// </summary>
[Serializable]
public struct Stats
{
    public int Health;
    public int AttackPower;
    public int TravelDistance;
}

[Serializable]
public enum Faction
{
    Heroes = 0,
    Enemies = 1
}