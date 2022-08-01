#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Architecture;
using excel = Microsoft.Office.Interop.Excel;
using Forms = System.Windows.Forms;

#endregion

namespace RevitAddinAcademy
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
        ExternalCommandData commandData,
        ref string message,
        ElementSet elements)



        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;


            Employee emp1 = new Employee("Joe", 24, "blue,red,white");
            Employee emp2 = new Employee("Mary", 26, "green,red,brown");
            Employee emp3 = new Employee("Joe", 24, "blue,red,white");


            List<Employee> empList = new List<Employee>();
            empList.Add(emp1);
            empList.Add(emp2);
            empList.Add(emp3);

            Employees allEmployee = new Employees(empList);

            Debug.Print("There are " + allEmployee.GetEmployeeCount().ToString() + " employees.");




            Debug.Print(Utilities.GetTextFromClass());



            List<SpatialElement> spatialElements = Utilities.GetAllRooms(Doc);
            foreach (SpatialElement curRoom in roomList)
            {
                LocationPoint
            } ();

        }
    }

}


           


            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            return Result.Succeeded;