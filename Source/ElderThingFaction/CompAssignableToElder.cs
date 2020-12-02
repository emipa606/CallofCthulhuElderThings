using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ElderThingFaction
{
    class CompAssignableToElder : CompAssignableToPawn_Bed
    {
        public override IEnumerable<Pawn> AssigningCandidates
        {
            get
            {
                if (!parent.Spawned)
                {
                    return Enumerable.Empty<Pawn>();
                }
                if (parent.def.defName.StartsWith("ET_"))
                {
                    return from Pawn pawn in parent.Map.mapPawns.FreeColonists where pawn.kindDef.defName.StartsWith("ElderThing_") select pawn;
                }
                return from Pawn pawn in parent.Map.mapPawns.FreeColonists where !pawn.kindDef.defName.StartsWith("ElderThing_") select pawn;
            }
        }
    }
}
