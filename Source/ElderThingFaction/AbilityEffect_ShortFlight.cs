using System;
using AbilityUser;
using Verse;

namespace ElderThingFaction
{
    public class AbilityEffect_ShortFlight : AbilityUser.Verb_UseAbility
    {
        protected override bool TryCastShot()
        {

            base.TryCastShot();
            Ability.CooldownTicksLeft = Ability.MaxCastingTicks;
            if (TargetsAoE[0] is LocalTargetInfo t && t.Cell != default)
            {
                Pawn caster = CasterPawn;
                LongEventHandler.QueueLongEvent(delegate ()
                {
                    var flyingObject =
                        GenSpawn.Spawn(ThingDef.Named("ElderThing_PFlyingObject"), CasterPawn.Position,
                            CasterPawn.Map) as FlyingObject;
                    flyingObject.Launch(CasterPawn, t.Cell, CasterPawn);
                }, "LaunchingFlyer", false, null);
            }

            return true;
        }
        
    }
}