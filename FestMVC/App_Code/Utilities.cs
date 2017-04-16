using FestMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace FestMVC.App_Code
{
    public class Utilities
    {
        public static string GetServerRoot(HttpServerUtilityBase server)
        {
            return server.MapPath(@"\");

        }

        public static string GetRelativeFilePath(string fileName, string root, string model, string id)
        {
            if (fileName == null) return "Empty File Name";
            return Path.Combine(root, model, id, Path.GetFileName(fileName));
        }

        public static void SaveFile(string path, HttpPostedFileBase file, HttpServerUtilityBase server)
        {
            string fullPath = Path.Combine(Utilities.GetServerRoot(server), path);//Actual phisical path for saving the file
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            file.SaveAs(fullPath);
        }

        public static void DeleteFile(string path, HttpServerUtilityBase server)
        {
            string fullPath = Path.Combine(Utilities.GetServerRoot(server), path);//Actual phisical path for saving the file
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }

        public static List<IbaseModel> FilterFestivalManager(List<IbaseModel> modelList, IPrincipal user)
        {
            if (user.IsInRole("FestivalManager"))
            {
                modelList = modelList.Where(x => x.getUserID() == user.Identity.GetUserId()).ToList();
                
            }
            return modelList;
        }

        public static bool FestivalManagerIsCurrentUser(IbaseModel model, string UserId)
        {
            if (model.getUserID() == UserId)
            {
                return true;
            }

            return false;
        }

        public static bool IsForbidden(IbaseModel model, IPrincipal user)
        {
            if (user.IsInRole("FestivalManager"))
            {
                if (model.getUserID() != user.Identity.GetUserId())
                {
                    return true;
                }
            }

            return false;
        }
    }
}