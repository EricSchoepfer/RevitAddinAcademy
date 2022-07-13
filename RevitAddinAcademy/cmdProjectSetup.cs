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

            string excelFile = @"Z:\Dropbox\Dropbox\EASy Designs\Automations\Archsmarter\Revit Add-In Academy\Session02_Challenge-220706-113155.xlsx";

            {
                {
                    // Open Excel

                    excel.Application excelApp = new excel.Application();
                    excel.Workbook excelWb = excelApp.Workbooks.Open(excelFile);

                    excel.Worksheet excelWsLevels = excelWb.Worksheets.Item[1];
                    excel.Worksheet excelWsSheets = excelWb.Worksheets.Item[2];


                    excel.Range excelRngLevels = excelWsLevels.UsedRange;
                    excel.Range excelRngSheets = excelWsSheets.UsedRange;

                    int rowCountLevels = excelRngLevels.Rows.Count;
                    int rowCountSheets = excelRngSheets.Rows.Count;

                    excelWb.Close();
                    excelApp.Quit();




                    using (Transaction t = new Transaction(doc))

                    {
                        t.Start("Create Some Revit Stuff");
                        for (int i = 2; i <= rowCountLevels; i++)
                        {
                            excel.Range leveldata1 = excelWsLevels.Cells[i, 1];
                            excel.Range leveldata2 = excelWsLevels.Cells[i, 2];

                            string levelName = leveldata1.Value.ToString();
                            double levelElev = leveldata2.Value;

                            Level newLevel = Level.Create(doc, levelElev);
                            newLevel.Name = levelName;
                            newLevel.Elevation = levelElev;
                        }


                        FilteredElementCollector collector = new FilteredElementCollector(doc);
                        collector.OfCategory(BuiltInCategory.OST_TitleBlocks);
                        collector.WhereElementIsElementType();



                        for (int j = 2; j <= rowCountSheets; j++)
                        {
                            excel.Range sheetdata1 = excelWsSheets.Cells[j, 1];
                            excel.Range sheetdata2 = excelWsSheets.Cells[j, 2];

                            string sheetNumber = sheetdata1.Value.ToString();
                            string sheetName = sheetdata2.Value;

                            ViewSheet newsheet = ViewSheet.Create(doc, collector.FirstElementId());
                            newsheet.Name = sheetName;
                            newsheet.SheetNumber = sheetNumber;

                        }

                        t.Commit();
                        t.Dispose();


                    }

                    return Result.Succeeded;
                }
            }
        }
    }
}


