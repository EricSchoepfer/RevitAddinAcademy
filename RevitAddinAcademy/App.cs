#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Diagnostics;
using System.Reflection;
using Autodesk.Revit.UI.Selection;

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
            //RibbonPanel curPanel = a.CreateRibbonPanel("Test Tab", "Test Panel");
            RibbonPanel curPanel = CreateRibbonPanel(a, "Test Tab", "Test Panel");

            // Step 3:  Create Button Data instances


            //  Step 4:  Add Images
           

            //  Step 5:  Add tolltip Infor


            //  Step 6:  Create Buttons





            
            
            
            
            
            return Result.Succeeded;
        }

        private RibbonPanel CreateRibbonPanel(UIControlledApplication a,
                                              string tabName,
                                              string panelName)
        {
            if (tabName is null)
            {
                throw new ArgumentNullException(nameof(tabName));
            }

            foreach (RibbonPanel tmpPanel in a.GetRibbonPanels(tabName))
                {
                    if(tmpPanel.Name == panelName)
                        return tmpPanel;
                }
            RibbonPanel returnPanel = a.CreateRibbonPanel(tabName, panelName);

            return returnPanel;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
