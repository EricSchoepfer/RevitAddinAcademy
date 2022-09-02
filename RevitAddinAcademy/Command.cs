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

            IList<Element> picklist = uidoc.Selection.PickElementsByRectangle("SELECT AREAS AND PERIMETERS");
            List<SpatialElement> AreaList = new List<SpatialElement>();
            List<BoundarySegment> seglist = new List<BoundarySegment>();

            
                {
                    foreach (Element element in picklist)
                    {
                        if (element is SpatialElement)
                        {
                            SpatialElement spatial = (SpatialElement)element;

                            AreaList.Add(spatial);

                            SpatialElementBoundaryOptions areas = new SpatialElementBoundaryOptions();

                            IList<IList<BoundarySegment>> boundseg = spatial.GetBoundarySegments(areas);

                             BoundarySegment seg = (seg.GetCurve);

                            IList<IList<BoundarySegment>>  
                        
                            foreach (CurveElement curv in boundseg)
                            {
                            if (curv != null)
                                {
                                seglist.Add(curv); 
                                }

                                

                            }


                            
                            
                            
                        }
                        

                    }


                }



                
            
                TaskDialog.Show("Complete", AreaList.Count.ToString());
                return Result.Succeeded;
            
        }

        

        //Methods------------------------------------------------------------------

       

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