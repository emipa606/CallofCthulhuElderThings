using RimWorld;
using System.Collections.Generic;
using Verse;

namespace ElderThingFaction
{
    public class PlaceWorker_NextToConsoleAccepter : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            for (var i = 0; i < 4; i++)
            {
                IntVec3 c = loc + GenAdj.CardinalDirections[i] + GenAdj.CardinalDirections[i];
                if (!c.InBounds(map))
                {
                    continue;
                }
                List<Thing> thingList = c.GetThingList(map);
                for (var j = 0; j < thingList.Count; j++)
                {
                    Thing groundThing = thingList[j];
                    if (!(GenConstruct.BuiltDefOf(groundThing.def) is ThingDef thingDef) || thingDef.building == null)
                    {
                        continue;
                    }
                    if (thingDef.defName == "ET_BiogenesisVat")
                    {
                        return true;
                    }
                }
            }
            return "MustPlaceNextToVatAccepter".Translate();
        }
    }
}