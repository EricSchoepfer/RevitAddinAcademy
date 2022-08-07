#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace RevitAddinAcademy
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            // Step 1:  Create Ribbon Tab

                try
                {
                a.CreateRibbonTab("test Tab");
                }
            catch (Exception)
                {
                Debug.Print("Tab Already Exist");
                }    

            // Step 2:  Create Ribbon Panel


            // Step 3:  Create Button Data instances


            //  Step 4:  Add Images
           

            //  Step 5:  Add tolltip Infor


            //  Step 6:  Create Buttons





            
            
            
            
            
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
