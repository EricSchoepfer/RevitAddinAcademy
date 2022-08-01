using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddinAcademy
{ using Autodesk.Revit.ApplicationServices;
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
}



 internal class myClass
 {

 }


public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<String> FavColors { get; set; }

    public Employee(string name, int age, string favColors)
    {
        Name = name;
        Age = age;
        FavColors = FormatColorList(favColors);
    }

    //Method
    private List<string> FormatColorList(string colorList)
    {
        List<string> returnList = colorList.Split(',').ToList();
        return returnList;
    }

}




public class Employees
{
    public List<Employee> EmployeeList { get; set; }

    public Employees(List<Employee> employees)
    {
        EmployeeList = employees;
    }
    public int GetEmployeeCount()
    {
        return EmployeeList.Count;
    }



}






 public static class Utilities
 {
    public static string GetTextFromClass()
    {
    return "I got this text from a static class";
    }

 }




public static List<SpatialElements> GetAllRooms(Document doc)
{
    FilteredElementCollector collector = new FilteredElementCollector(doc);
        collector.OfCategory(BuiltInCategory.OST_Rooms);

    List<SpatialElement> roomList = colorList.Split(',').ToList();


}





}
