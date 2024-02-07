//using RashakaGroupsAdmin.Repository.Interfaces;
//using RashakaGroupsAdmin.Repository.UniteOfWork;
//using RashakaGroupsAdmin.Models;
//using RashakaGroupsAdmin.Repository.Interfaces;
//using RashakaGroupsAdmin.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Web;


//namespace RashakaGroupsAdmin.Repository
//{
//    public class LoginService : ILogin
//    {
//        IRashakaUniteOfWork repo;
//        public LoginService()
//        {
//            repo = new RashakaUniteOfWork();
//        }
//        public Login Login(Login user)
//        {
//            Login adminData = repo.iRashaka<Login>().GetBy(a => a.accountId > 0 && a.userName.ToLower() == user.userName.ToLower() && a.password == user.password);
//            if (adminData != null)
//            {
//                Account account = repo.iRashaka<Account>().Find(adminData.accountId);
//                string groupId = adminData.groupId;
//                LoginService.Login(adminData, account);
//            }
//            return adminData;
//        }
//    }
//}