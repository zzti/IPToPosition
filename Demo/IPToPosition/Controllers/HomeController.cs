﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPToPosition.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// IP归属地查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IPAndPositionHelper.EnableFileWatch = true; // 默认值为：false，如果为true将会检查ip库文件的变化自动reload数据

            string path = Server.MapPath("/APP_Data/IPDB20151001.dat");
            if (string.IsNullOrEmpty(path) || System.IO.Path.GetExtension(path) != ".dat")
            {
                return View();
            }

            IPAndPositionHelper.Load(path);//加载
           
            //JsonHelper.ToJson(IPAndPositionHelper.Find("210.21.113.236"));
            ViewBag.infos = IPAndPositionHelper.Find("183.209.0.207");//查询

            return View();
        }
    }
}