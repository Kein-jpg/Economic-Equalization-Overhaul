﻿using HarmonyLib;
using PavonisInteractive.TerraInvicta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TIEconomyMod
{
    [HarmonyPatch(typeof(TINationState), "unityPriorityCohesionChange", MethodType.Getter)]
    public static class UnityCohesionEffectPatch
    {
        [HarmonyPrefix]
        public static bool GetUnityPriorityCohesionChangeOverwrite(ref float __result, TINationState __instance)
        {
            //Patch changes the cohesion effect of a unity investment to scale inversely with population size

            // Refer to EffectStrength() comments for explanation.
            float baseEffect = Tools.EffectStrength(1.0f, __instance.population);

            // Democracy and Education incurs a 2.5% malus per point, up to -50%.
            // A combined score of 15 causes the max effect.
            float penaltyMult = Mathf.Min(0.5f, 1f - ((__instance.education + __instance.democracy) * 0.025f));

            __result = baseEffect * penaltyMult;



            return false; //Skip original getter
        }
    }
}
