﻿using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace CombineParameters 
{
    class ExternalApplication : IExternalApplication
    {
        //UIControlledApplication is object that has passesd to the method
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication app)
        {
            //Create Ribbon Element
            //нет необходимости использовать переменные
            app.CreateRibbonTab("ДАК ПРОДЖЕКТ");
            string path = Assembly.GetExecutingAssembly().Location;
            //needs to be string, therefore using quotation marks 
            PushButtonData button = new PushButtonData("QWERTY", "Нажмите для объединения параметров", path, "CombineParameters.Class" );
            //panel - group of commands
            RibbonPanel panel = app.CreateRibbonPanel("ДАК ПРОДЖЕКТ", "Объединение параметров");
            PushButton pushButton = panel.AddItem(button) as PushButton;
      
            return Result.Succeeded;
        }
    }
}
