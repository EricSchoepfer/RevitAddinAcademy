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
    public class CmdInsertFurniture : IExternalCommand
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

            int counter = 0;

            string excelfile = "";

            Forms.OpenFileDialog ofd = new Forms.OpenFileDialog();
            ofd.Title = "Select Furniture Excel File";
            ofd.InitialDirectory = @"c:\";
            ofd.Filter = "Excel Files (*.xlsx";

            if (ofd.ShowDialog() != Forms.DialogResult.OK)
                return Result.Failed;

            excelfile = ofd.FileName;

            List<string[]> excelFurnSetData = GetDataFromExcel(excelfile, "Furniture sets", 3);
            List<string[]> excelFurnData = GetDataFromExcel(excelfile, "Furniture types", 3);

            excelFurnSetData.RemoveAt(0);
            excelFurnData.RemoveAt(0);

            List<FurnSet> furnSetlist = new List<FurnSet>();
            List<FurnData> furnDataList = new List<FurnData>();


            foreach (string[] curRow in excelFurnSetData)
            {
                FurnSet tmpFurnSet = new FurnSet(curRow[0].Trim(), curRow[1].Trim(), curRow[2].Trim());
                furnSetlist.Add(tmpFurnSet);
            }
           
            foreach (string[] curRow in excelFurnData)
            {
                FurnData tmpfurnData = new FurnData(curRow[0].Trim(), curRow[1].Trim(), curRow[2].Trim());
                furnDataList.Add(tmpfurnData);
            }
           
            return Result.Succeeded;
        }

        private List<string[]> GetDataFromExcel(string excelfile, string wsName, int numColumns)
        {
          excel.Application excelApp = new excel.Application();
          excel.Workbook excelWB = excelApp.Workbooks.Open(excelfile);

          excel.Worksheet excelWs = GetExcelWorksheetByName(excelWB, wsName);
          excel.Range excelRng = excelWs.UsedRange as excel.Range;
            
          int rowCount = excelRng.Rows.Count;

          List<string[]> data = new List<string[]>();

            for(int i = 1; i <= rowCount; i++)
            {
                string[] rowData = new string[numColumns];

                for(int j = 1; j <= numColumns; j++)
                {
                    excel.Range cellData = excelWs.Cells[i, j];
                    rowData[j - 1] = cellData.ToString();
                }

                data.Add(rowData);
            }

            excelWB.Close();
            excelApp.Quit();



        }

        private excel.Worksheet GetExcelWorksheetByName(excel.Workbook excelWB, string wsName)
        {
          foreach(excel.Worksheet sheet in excelWB.Worksheets)
            {
                if (sheet.Name == wsName) 
                    return sheet;
            }
        }
    }

}
 