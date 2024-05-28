using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;

namespace ThorofareModMenu
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class ModMenuInjection : BaseUnityPlugin
    {
        public const string pluginGuid = "laymglitched.firewatch.thorofaremodmenu";
        public const string pluginName = "Thorofare Mod Menu";
        public const string pluginVersion = "0.0.1";

        public void Awake()
        {
            Logger.LogInfo("Creating Object..");
            GameObject modMenu = new GameObject("Thorofare Mod Menu");
            Logger.LogInfo("Done! Putting it in DontDestroyOnLoad..");
            DontDestroyOnLoad(modMenu);
            Logger.LogInfo("Done! Adding UI Script");
            modMenu.AddComponent<ModMenuUI>();
            Logger.LogInfo("Done! Injection finished! Doing next steps..");
        }
    }
}
