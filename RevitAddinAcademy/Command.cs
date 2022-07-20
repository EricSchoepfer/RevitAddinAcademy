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
using Autodesk.Revit.DB.Architecture;

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


            WallType curWallType = GetWallTypeByName(doc, @"Generic - 8""");
            Level curLevel = GetLevelByName(curLevel "Level 1");



            
            foreach (Element element in picklist)
            {
                if (element is CurveElement)

                {


                    CurveElement curve = (CurveElement)element;
                    CurveElement curve2 = element as CurveElement;

                    curveList.Add(curve);

                    GraphicsStyle curGS = curve.LineStyle as GraphicsStyle;


                    switch (curGS.Name)
                    {
                        case "<Medium>";
                            Debug.Print("found a medium line");
                                break;

                            case "<Think Lines>";
                            Debug.Print("found a think  line");
                            break;

                            case "<Wide Lines>";
                            Pipe newPipe = Pipe.Create(
                                doc,
                                CurSystemType.Id,
                                curPipeType.Id,
                                curLevel.Id,
                                startPoint,
                                endpoint);
                    }

                    Curve curCurve = curve.GeometryCurve;
                    XYZ startPoint = curCurve.GetEndPoint(0);
                    XYZ endPoint = curCurve.GetEndPoint(1);

                    //Wall newWall = Wall.Create(doc, curCurve, curWallType.Id, curLevel.Id, 15, 0, false, false);
                   
                    
                    Debug.Print(curGS.Name);

                }
            }




           TaskDialog.Show("Complete", curveList.Count.ToString());


            return Result.Succeeded;
        }





        private WallType GetWallTypeByName(Document doc, string wallTyoeName)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(WallType));

            foreach (Element curElem in collector)
            {
                WallType wallType = curElem as WallType;
                if (curElem.Name == wallTyoeName)
                    return wallType;

            }

        }

        private Level GetLevelByName(Document doc, string Level)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(Level));

            foreach (Element curElem in collector)
            {
                WallType wallType = curElem as WallType;
                if (curElem.Name == Level)
                    return curLevel;

            }

        }



    }
}
