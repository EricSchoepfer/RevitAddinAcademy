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

            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            IList<Element> picklist = uidoc.Selection.PickElementsByRectangle("Select some element");
            List<CurveElement> curveList = new List<CurveElement>();


            WallType WallType1 = GetWallTypeByName(doc, @"Generic - 8""");
            WallType WallType2 = GetWallTypeByName(doc, @"Generic - 8""");

            Level curLevel = GetLevelByName(doc, "Level 1");


            MEPSystemType curSystemType = GetSystemTypeByName(doc, "Domestic Hot Water");
            PipeType curPipeType = GetPipeTypeByName(doc, "Default");
            MEPSystemType curDuctType = GetSystemTypeByName(doc, "Default");


            using (Transaction t = new Transaction(doc))

            {
                t.Start("Create Revvit Stuff");

                foreach (Element element in picklist)
                {
                    if (element is CurveElement)

                    {

                        // casting to element type
                        CurveElement curve = (CurveElement)element;
                        //similar method
                        CurveElement curve2 = element as CurveElement;



                        curveList.Add(curve);


                        //    2 methods similar as above
                        //GraphicsStyle curGS = curve.LineStyle as GraphicsStyle;  (METHOD 1)
                        GraphicsStyle curGS = (GraphicsStyle)curve.LineStyle;


                        
                                                

                                    Curve curCurve = curve.GeometryCurve;
                                    XYZ startPoint;
                                    XYZ endPoint;

                        try
                        {
                            XYZ startPoint = curCurve.GetEndPoint(0);
                            XYZ endPoint = curCurve.GetEndPoint(1);
                        }
                        catch (Exception)
                        {
                            startPoint = null;
                            endPoint = null;
                        }





                        try
                        {                  
                      
                             switch (curGS.Name)
                                    {

                                            case "<M-DUCT>":
                                                Duct.Create(
                                                doc,
                                                curSystemType.Id,
                                                curPipeType.Id,
                                                curLevel.Id,
                                                startPoint,
                                                endPoint);
                                                break;


                                            case "<P-PIPE>":
                                                Pipe.Create(
                                                doc,
                                                curSystemType.Id,
                                                curPipeType.Id,
                                                curLevel.Id,
                                                startPoint,
                                                endPoint);
                                                break;


                                            case "<A-WALL>":
                                                Wall.Create(
                                                doc,
                                                curCurve,
                                                WallType1.Id,
                                                curPipeType.Id,
                                                curLevel.Id,
                                                20,
                                                0,                                                
                                                false,
                                                false,
                                                break;


                                            case "<A-GLAZ>":
                                                Wall.Create(
                                                doc,
                                                WallType2.Id,
                                                curPipeType.Id,
                                                curLevel.Id,
                                                20,
                                                0,
                                                false,
                                                false,
                                                break;


                                            case "<Medium>":
                                                Debug.Print("found a medium line");
                                                break;

                                            case "<Thin Lines>":
                                                Debug.Print("found a thin  line");
                                                break;

                                            case "<Wide Lines>":
                                                Pipe newPipe = Pipe.Create(
                                                doc,
                                                curSystemType.Id,
                                                curPipeType.Id,
                                                curLevel.Id,
                                                startPoint,
                                                endPoint);
                                                break;

                                            default:
                                            Debug.Print("Found Something Else");
                                            break;
                                    }
                               


                        //Original wall create method--------------------------------------------------------------
                     //Wall newWall = Wall.Create(doc, curCurve, curWallType.Id, curLevel.Id, 15, 0, false, false);
                        //----------------------------------------------------------------------------------------------

                        Debug.Print(curGS.Name);
                    }

                   
                }

                t.Commit();


                TaskDialog.Show("Complete", curveList.Count.ToString());
                return Result.Succeeded;


            }

            //Methods------------------------------------------------------------------


        }
            private WallType GetWallTypeByName(Document doc, string wallTyoeName)
            {
             FilteredElementCollector collector = new FilteredElementCollector(doc);
             collector.OfClass(typeof(WallType));

                foreach (Element curElem in collector)
                {
                 WallType wallType = curElem as WallType;

                    if(wallType.Name == wallTyoeName)
                     return wallType;
                }
                return null;
            }


             private Level GetLevelByName(Document doc, string LevelName)
             {
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                collector.OfClass(typeof(Level));

                foreach (Element curElem in collector)
                {
                 Level Level = curElem as Level;

                    if (Level.Name == LevelName)
                    return Level;
                }
                    return null;
             }



            private MEPSystemType GetSystemTypeByName(Document doc, string TypeName)
            {
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                 collector.OfClass(typeof(MEPSystemType));

                foreach (Element curElem in collector)
                {
                    MEPSystemType curType = curElem as MEPSystemType;

                    if (curType.Name == TypeName)
                    return curType;
                }
                return null;
            }



            private PipeType GetPipeTypeByName(Document doc, string TypeName)
            {
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                collector.OfClass(typeof(PipeType));

                foreach (Element curElem in collector)
                {
                    PipeType curType = curElem as PipeType;

                    if (curType.Name == TypeName)
                    return curType;
                }
                    return null;
            }
        }
}



    //case "<M-DUCT>":
                                //Duct newDuct = Duct.Create(
                                //doc,
                                //curSystemType.Id,
                                //curPipeType.Id,
                                //curLevel.Id,
                                //startPoint,
                                //endPoint);
        //break;


//case "<P-PIPE>":
                               // Pipe newPipe = Pipe.Create(
                                //doc,
                                //curSystemType.Id,
                                //curPipeType.Id,
                                //curLevel.Id,
                                //startPoint,
                                //endPoint);
//break;