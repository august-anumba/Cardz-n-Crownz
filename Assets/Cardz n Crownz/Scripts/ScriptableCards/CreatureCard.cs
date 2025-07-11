﻿// Put all our items in the Resources folder. We use Resources.LoadAll down
// below to load our items into a cache so we can easily reference them.
using UnityEngine;
using System.Collections.Generic;

public enum CreatureType : byte { BEAST, DRAGON, ALL }

// Struct for cards in your deck. Card + amount (ex : Sinister Strike x3). Used for Deck Building. Probably won't use it, just add amount to Card struct instead.
[CreateAssetMenu(menuName = "Card/Creature Card", order = 111)]
public partial class CreatureCard : ScriptableCard
{
    [Header("Stats")]
    public int strength;
    public int health;

    [Header("Targets")]
    public List<Target> acceptableTargets = new List<Target>();

    [Header("Type")]
    public List<CreatureType> creatureType;

    [Header("Specialities")]
    public bool hasCharge = false;
    public bool hasTaunt = false;

    [Header("Death Abilities")]
    public List<CardAbility> deathcrys = new List<CardAbility>();
    [HideInInspector] public bool hasDeathCry = false; // If our card has a DEATHCRY ability

    [Header("Board Prefab")]
    public FieldCard cardPrefab;

    public virtual void Attack(Entity attacker, Entity target)
    {
        target.combat.CmdChangeHealth(-attacker.strength);
        attacker.DestroyTargetingArrow();
        attacker.combat.CmdIncreaseWaitTurn();
        //int chipAmount = 0;

        //if (attacker.strength > target.health)
        //{
        //  chipAmount = attacker.strength - target.health;
        //if (chipAmount < 0)
        //{
        //   chipAmount = 0;
        //}
        //if (chipAmount > 0)
        //{
        //  Debug.Log(chipAmount);
        //Player.localPlayer.combat.CmdChangeHealthChip(-chipAmount);
        //           }
        //     target.combat.CmdChangeHealth(-attacker.strength);
        //   attacker.DestroyTargetingArrow();
        // attacker.combat.CmdIncreaseWaitTurn();
        //        }
        //
        //        if (attacker.strength == target.health)
        //        {
        //            
        //           target.combat.CmdChangeHealth(-attacker.strength);
        //         attacker.combat.CmdChangeHealth(-target.strength);
        //       attacker.DestroyTargetingArrow();
        //     attacker.combat.CmdIncreaseWaitTurn();
        //      }

        //    if (attacker.strength < target.health)
        //  {
        //
        //    target.combat.CmdChangeHealth(-attacker.strength);
        //  attacker.combat.CmdChangeHealth(-target.strength);
        // attacker.DestroyTargetingArrow();
        // attacker.combat.CmdIncreaseWaitTurn();
        //    }
    }


    public void Update()
    {
        if (deathcrys.Count > 0) hasDeathCry = true;

        // By default, all creatures can only attack enemy creatures and our opponent. We set it here so every card get it's automatically.
        if (acceptableTargets.Count == 0)
        {
            acceptableTargets.Add(Target.ENEMIES);
            acceptableTargets.Add(Target.OPPONENT);
        }


    }
}