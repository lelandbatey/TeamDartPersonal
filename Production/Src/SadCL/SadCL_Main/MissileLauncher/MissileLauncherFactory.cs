﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadCL.MissileLauncher
{
    public enum LauncherTypes
    {
        Mock = 0,
        DreamCheeky = 1
    }
   
    public class MissileLauncherFactory
    {
        public static IMissileLauncher create_Launcher(LauncherTypes Product)
        {
            IMissileLauncher generatedLauncher = null;

            if (Product == LauncherTypes.Mock)
            {
                generatedLauncher = new MockLauncher();
            }
            else if (Product == LauncherTypes.DreamCheeky)
            {
                generatedLauncher = new DreamCheekyLauncher("Photon Cannon");
            }
            else
                throw new ArgumentException("The product you want me to create doesn't exist in my database.");

            return generatedLauncher;
        }
    }
}
