#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;

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

            IList<Element> picklist = uidoc.Selection.PickElementsByRectangle("Select Model Slement");

            WallType curWallType = GetWallTypeByName(doc, @"Generic - 8""");
            Level curLevel = GetLevelByName(doc, "Level 1");


            MEPSystemType curSystemType = GetSystemTypeByName(doc, "Domestic Hot Water");
            PipeType curPipeType = GetPipeTypeByName(doc, "Default");
            MEPSystemType curDuctType = GetSystemTypeByName(doc, "Default");


            foreach (Element element in picklist)
            {
                if(element is CurveElement)
                {
                  
                }


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

                            if (wallType.Name == wallTyoeName)
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



                    private MEPSystemType GetMEPSystemTypeByName(Document doc, string TypeName)
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



                    private PipeType GetMEPSystemTypeByName(Document doc, string TypeName)
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