using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GU.Models;
using GU.Data;
using Microsoft.AspNetCore.Http;
using GU.Class;
using Microsoft.Extensions.Configuration;

namespace SMS.ViewComponents
{
    public class MenuListViewComponent : ViewComponent
    {
        private readonly GU_DB _context;

        private IConfiguration _iconfiguration;

        public MenuListViewComponent(GU_DB context, IConfiguration iconfiguration)
        {
            _context = context;
            _iconfiguration = iconfiguration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userid = HttpContext.Session.GetString("User_ID");

            var UserInfo = await _context.User.Where(m => m.User_ID == Convert.ToInt16(userid)).ToListAsync();
            ViewData["User"] = UserInfo;

            return View();

            //if(userid == null || roleid == null){

            //    return View();
            //}
            //else
            //{
            //    //var MenuInfo = await _context.UserInfo.Where(m => m.userid == Convert.ToInt16(userid)).ToListAsync();
            //    //ViewData["User"] = MenuInfo;
            //    //ViewData["CurrentCapital"] = await _context.Capital_Detail.Where(m => m.Capital_ID == Convert.ToInt16(capitalid)).ToListAsync();
            //    //var username_String = _context.UserInfo.Where(m => m.userid == Convert.ToInt16(userid)).Select(s => s.username).SingleOrDefault().ToString();
            //    //var role_name = _context.UserInfo.Include(w => w.RoleMaster).Where(s => s.userid == Convert.ToInt16(userid)).Select(c => c.RoleMaster.RoleName).SingleOrDefault();

            //    //ViewData["Username"] = username_String;
            //    //ViewData["RoleName"] = role_name;
            //    //"Stockholder#Index"
            //    //TempData["MenuList"] = generateMenu(Convert.ToInt16(roleid));
            //    return View(MenuInfo);

            //}

        }

        

    }
}
