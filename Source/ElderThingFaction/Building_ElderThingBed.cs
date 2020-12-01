using Verse;
using RimWorld;

namespace ElderThingFaction
{
    public class Building_ElderThingBed : Building_Bed
    {
        private CompSecondLayer bedDoor;

        public override void SpawnSetup(Map map, bool blabla)
        {
            base.SpawnSetup(map, blabla);
            bedDoor = GetComp<CompSecondLayer>();
        }

        public bool IsPawnSleeping()
        {
            if (CurOccupants?.RandomElement() != null)
            {
                return true;
            }

            return false;
        }

        public override void Tick()
        {
            base.Tick();
            if (bedDoor == null)
            {
                return;
            }

            if (!IsPawnSleeping()) { bedDoor.ShowNow = false; return; }
            bedDoor.ShowNow = true;
        }
    }
}
