﻿namespace TIEconomyMod
{
    // This is a helper class used to streamline things, and centralize important variables.
    public static class Tools
    {
        public static float GDPPerIP = 100000000000f;

        // These are declared outside of EffectStrength() because that function will be called several times. Also it looks nice IMO.
        // For an explanation as to why I did this, check the comments inside the function.
        private static float theoreticalGDP = GDPPerIP; //1 IP
        private static float theoreticalPCGDP = 30000f;
        private static float theoreticalPopulation = theoreticalGDP / theoreticalPCGDP;

        public static float EffectStrength(float idealGainPerMonth, float population)
        {
            /* Calculates the effect strength for inverse population scaling. 
             * 
             * A nation with 30k GDP per-capita will, if putting all of its focus on the relevant priority, increase a particular nation stat by [idealGainPerMonth].
             * 
             * For example, if Welfare's Inequality reduction [idealGainPerMonth] is -0.1, and GDP/pc is 30k, then Inequality is reduced at a rate of 0.1 a month. 
             * 
             * If it's 60k, then the effect is 0.2 per month.
             * If it's 15k, then the effect is 0.05 per month.
             * And so on.
             * 
             * The effect strength you will see in-game will likely be much, much less, unless the nation generates less than 1 IP a month.
             * */

            /* The following reasoning is used in the below equation:
             * 
             * Let's say the country has a GDP of 100 billion. They generate 1 IP per month.
             * The GDP per capita is 30k. Therefore, they have a population of 3.33 million.
             * 
             * This then is divided by the nation's population to get the final effect strength.
             * */

            // TLDR: If a nation has 30k GDP per capita, a stat will be changed by [idealGainPerMonth] a month.

            float effectStrength = idealGainPerMonth * theoreticalPopulation;

            return effectStrength / population;
        }
    }
}
