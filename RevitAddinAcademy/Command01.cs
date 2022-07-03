#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.IO;

#endregion

namespace RevitAddinAcademy
{
    [Transaction(TransactionMode.Manual)]
    public class Command01 : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            String text = "Revit Add-In Academy";
            String fileName = doc.PathName;

            double offset = 0.05;
            double offsetCalc = offset * doc.ActiveView.Scale;
            double textSpace = 0.25;


            XYZ curPointf = new XYZ(0, 0, 0);
            XYZ offsetPointf = new XYZ(0, offsetCalc, 0);

            XYZ curPointb = new XYZ(12, 0, 0);
            XYZ offsetPointb = new XYZ(0, offsetCalc, 0);

            XYZ curPointfb = new XYZ(25, 0, 0);
            XYZ offsetPointfb = new XYZ(0, offsetCalc, 0);




            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(TextNoteType));

            Transaction t = new Transaction(doc, "Create Text Note");
            t.Start();

            int range = 300;
            for (int f = 1; f <= range; f++)
            {
            TextNote curNote = TextNote.Create(doc, doc.ActiveView.Id, curPointf, "Fizz " + f.ToString(), collector.FirstElementId());
            curPointf = curPointf.Subtract(offsetPointf); 
            }

            for (int b = 1; b <= range; b++)
            {
                TextNote curNote = TextNote.Create(doc, doc.ActiveView.Id, curPointb, "Buzz " + b.ToString(), collector.FirstElementId());
                curPointb = curPointb.Subtract(offsetPointb);
            }

            for (int fb = 1; fb <= range; fb++)
            {
                TextNote curNote = TextNote.Create(doc, doc.ActiveView.Id, curPointfb, "FizzBuzz " + fb.ToString(), collector.FirstElementId());
                curPointfb = curPointfb.Subtract(offsetPointfb);
            }


            t.Commit(); 
            t.Dispose();
            return Result.Succeeded;
        }

        internal double Method01(double a, double b)
        {
            double c = a + b;
            Debug.Print("Got here: " + c.ToString());

            return c;   
        }
    }
}

