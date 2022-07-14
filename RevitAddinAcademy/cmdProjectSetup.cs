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
using excel = Microsoft.Office.Interop.Excel;
using Forms = System.Windows.Forms;


#endregion

namespace RevitAddinAcademy
{
    [Transaction(TransactionMode.Manual)]
    public class cmdProjectSetup : IExternalCommand
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

            Forms.OpenFileDialog dialog = new Forms.OpenFileDialog();
            dialog.InitialDirectory = @"C:/";
            dialog.Multiselect = true;
            dialog.Filter = "Revit Files | *.rvt; *.rfa";

            string filePath = "";
            if(dialog.ShowDialog() == Forms.DialogResult.OK)
            {
                //filePath = dialog.FileName;
                filePath = dialog.FileName;
            }

            Forms.FolderBrowserDialog folderFDialog = new Forms.FolderBrowserDialog();

            string folderPath = "";
            if(folderFDialog.ShowDialog() == Forms.DialogResult.OK)
            {
                folderPath = folderFDialog.SelectedPath;
            }


            Tuple<string, int> t1 = new Tuple<string, int>("string 1", 55);
            Tuple<string, int> t2 = new Tuple<string, int>("string 2", 155);

            TestStruct struct1;
            struct1.Name = "Structure 1";
                struct1.Value = 100;
            struct1.Value2 = 10.5;

            TestStruct struct2 = new TestStruct("structure 1", 10, 1004.4);


            List<TestStruct> structlist = new List<TestStruct>();
            structlist.Add(struct1);


          

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(ViewFamilyType));

            FilteredElementCollector collector2 = new FilteredElementCollector(doc);
            collector.OfClass(typeof(ViewFamilyType));



            ViewFamilyType curVFT = null;
            ViewFamilyType curRCPVFT = null;
            foreach (ViewFamilyType curElem in collector)
            {
                if(curElem.ViewFamily == ViewFamily.FloorPlan)
                {
                    curVFT = curElem;
                }
                if(curElem.ViewFamily == ViewFamily.CeilingPlan)
                {
                    curRCPVFT = curElem;
                }
            }



            Level newLevel = Level.Create(doc, 100);
            ViewPlan curPlan = ViewPlan.Create(doc, curVFT.Id, newLevel.Id);
            ViewPlan curRCP = ViewPlan.Create(doc, curRCPVFT.Id, newLevel.Id);
            curRCP.Name = curRCP.Name + " RCP";

            ViewSheet viewSheet = ViewSheet.Create(doc, collecotr2.firstelementID);
            Viewport viewPort = Viewport.Create(doc, newsheet.Id, new XYZ(0, 0, 0));

            newSheet.Name = "Test Sheet";
            newSheet.SheetNumber = "a10010101";


            foreach(Parameter curParam in newSheet.Parameters)
            {
                if(curParam.Definition.Name == "Drawn By")
                {
                    curParam.Set("MM");
                        
                }
            }

            return Result.Succeeded;
                }

        internal View GetViewByName(Document dox, String viewName)
        {
            FilteredElementCollector collector = new FilteredElementCollector(dox);
            collector.OfClass(typof((View)));

            foreach(View curView in collector)
            {
                if (curView.Name == viewName)
            }
        }




        internal struct TestStruct
        {
            public string Name;
            public int Value;
            public double Value2;
            public TestStruct(string name, int value, double value2)
            {
                Name = name;
                Value = value;
                Value2 = value2;
            }




                 
        }


    }
}


