using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace plant_locator_tool
{
    public static class WindowOpenCheck
    {
        public static bool IsWindowOpen(string windowName)
        {
            foreach(Window openWindow in System.Windows.Application.Current.Windows)
            {
                if(openWindow.GetType().ToString() == $"plant_locator_tool.{windowName}")
                {
                    return true;
                }
            }

            return false;
        }

    }
}
