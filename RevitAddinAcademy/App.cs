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
                    a.CreateRibbonTab("Revit Add-in Academy");
                    }
                catch (Exception)
                    {
                    Debug.Print("Tab Already Exist");
                    }

            // Step 2:  Create Ribbon Panel
            //RibbonPanel curPanel = a.CreateRibbonPanel("Test Tab", "Test Panel");
            RibbonPanel curPanel = CreateRibbonPanel(a, "Revit Add-in Academy", "Revit Tools");

            // Step 3:  Create Button Data instances
            string assemblyName = GetAssemblyName();
            PushButtonData pData1 = new PushButtonData("Tool1", "Tool 1", GetAssemblyName(), "RevitAddinAcademy.command");
            PushButtonData pData2 = new PushButtonData("Tool2", "Tool 2", GetAssemblyName(), "RevitAddinAcademy.command");
            PushButtonData pData3 = new PushButtonData("Tool3", "Tool 3", GetAssemblyName(), "RevitAddinAcademy.command");
            PushButtonData pData4 = new PushButtonData("Tool4", "Tool 4", GetAssemblyName(), "RevitAddinAcademy.command");
            PushButtonData pData5 = new PushButtonData("Tool5", "Tool 5", GetAssemblyName(), "RevitAddinAcademy.command");
            PushButtonData pData6 = new PushButtonData("Tool6", "Tool 6", GetAssemblyName(), "RevitAddinAcademy.command");
            PushButtonData pData7 = new PushButtonData("Tool7", "Tool 7", GetAssemblyName(), "RevitAddinAcademy.command");
            PushButtonData pData8 = new PushButtonData("Tool8", "Tool 8", GetAssemblyName(), "RevitAddinAcademy.command");
            PushButtonData pData9 = new PushButtonData("Tool9", "Tool 9", GetAssemblyName(), "RevitAddinAcademy.command");
            PushButtonData pData10 = new PushButtonData("Tool10", "Tool 10", GetAssemblyName(), "RevitAddinAcademy.command");






            //  Step 4:  Add Images


            //  Step 5:  Add tolltip Infor


            //  Step 6:  Create Buttons










            return Result.Succeeded;
        }

        private string GetAssemblyName()
        {
            return Assembly.GetExecutingAssembly().Location;
        }



        private RibbonPanel CreateRibbonPanel(UIControlledApplication a,
                                              string tabName,
                                              string panelName)
        {
            
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
