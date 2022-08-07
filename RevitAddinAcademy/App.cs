#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

#endregion

namespace RevitAddinAcademy
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            // Step 1:  Create Ribbon Tab


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
