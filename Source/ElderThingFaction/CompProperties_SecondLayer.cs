using Verse;

namespace ElderThingFaction
{
    /*
     *
     *  Vendan is the original creator of this class.
     *  Bless
     *  -Jecrell 
     * 
     */
    internal class CompProperties_SecondLayer : CompProperties
    {
        public GraphicData graphicData;

        public AltitudeLayer altitudeLayer;

        public float Altitude => Altitudes.AltitudeFor(altitudeLayer);

        public CompProperties_SecondLayer()
        {
            compClass = typeof(CompSecondLayer);
        }
    }
}
