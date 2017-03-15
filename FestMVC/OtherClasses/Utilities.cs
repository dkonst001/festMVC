using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestMVC.OtherClasses
{
    public class Utilities
    {
        public static string GetServerRoot(HttpServerUtilityBase server)
        {
            return server.MapPath(@"\");

        }

        public static string GetRelativeFilePath (string fileName, string root, string model, long id)
        {
            return Path.Combine(root, model, "" + id, Path.GetFileName(fileName));
        }

        public static void SaveFile(string path, HttpPostedFileBase file, HttpServerUtilityBase server)
        {
            string fullPath = Path.Combine(OtherClasses.Utilities.GetServerRoot(server), path);//Actual phisical path for saving the file
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            file.SaveAs(fullPath);
        }

        public static void DeleteFile(string path, HttpServerUtilityBase server)
        {
            string fullPath = Path.Combine(OtherClasses.Utilities.GetServerRoot(server), path);//Actual phisical path for saving the file
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }
}