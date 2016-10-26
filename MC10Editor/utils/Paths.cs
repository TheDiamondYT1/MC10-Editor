using System;

namespace MC10Editor.Utils
{
    static class Paths
    {
        private static string baseMCpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
              @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang";

        public static string GetMCPath()
        {
            return baseMCpath;
        }

        public static string GetWorldsPath()
        {
            return GetMCPath() + @"\minecraftWorlds";
        }

        public static string GetResourcesPath()
        {
            return GetMCPath() + @"\resource_packs";
        }

    }
}
