﻿using HarmonyLib;
using PavonisInteractive.TerraInvicta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/* Pending deletion; Knowledge no longer has a Democracy modifier. */

namespace TIEconomyMod
{
    [HarmonyPatch(typeof(TINationState), "governmentPriorityDemocracyChange", MethodType.Getter)] /* Was 'knowledgePriorityDemocracyChange', but it looks like the method was renamed to 'governmentPriorityDemocracyChange'. Seems to work. */
    public static class KnowledgeDemocracyEffectPatch
    {
        [HarmonyPrefix]
        public static bool GetGovernmentPriorityDemocracyChangeOverwrite(ref float __result, TINationState __instance)
        {
            //Patch changes the democracy effect of a knowledge investment to scale inversely with population size

            // Refer to EffectStrength() comments for explanation.
            float baseEffect = Tools.EffectStrength(0.05f, __instance.population);

            // Each full point of Education gives +10% Democracy score.
            float educationMult = 1f + (__instance.education * 0.1f);

            __result = baseEffect * educationMult;



            return false; //Skip original getter
        }
    }
}
