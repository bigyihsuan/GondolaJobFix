using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using UnityEngine;
using UnityModManagerNet;
using HarmonyLib;

using DV.Logic.Job;

namespace GondolaJobFix
{
    class Main
    {
		static void Load(UnityModManager.ModEntry modEntry)
		{
			modEntry.Logger.Log("Loaded");

			if (AccessTools.Field(typeof(CargoTypes), "CarTypeToContainerType")?.GetValue(null)
					is Dictionary<TrainCarType, CargoContainerType> ct2ct)
			{
				ct2ct[TrainCarType.GondolaGreen] = CargoContainerType.Gondola;
				ct2ct[TrainCarType.GondolaGray] = CargoContainerType.Gondola;
			}
			else
			{
				modEntry.Logger.Warning("Failed to add green and gray gondolas to CarTypeToContainerType");
			}

			var harmony = new Harmony(modEntry.Info.Id);
			harmony.PatchAll(Assembly.GetExecutingAssembly());

			modEntry.Logger.Log("Finished");
		}
	}
}
