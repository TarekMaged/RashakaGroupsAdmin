using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.ViewModel;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.Repository
{
    public class AdminGroupsRepo
    {
        IRashakaUniteOfWork repo;
        IAdminUsers iAdminUsers;
        public AdminGroupsRepo(IAdminUsers iAdminUsers, IRashakaUniteOfWork _repo)
        {
            repo = _repo;
            this.iAdminUsers = iAdminUsers; 
        }
        public AdminGroupDetailsVM GetGroupDetails(int? id)
        {
            int? accountId = iAdminUsers.GetLoggedUserId();
            var group = repo.iRashaka<Group>().GetBy(x => x.id == id /*&& x.creatorId == accountId*/);
            if (group!=null&& accountId>0)
            {
             AdminGroupDetailsVM model = new AdminGroupDetailsVM
            {
                group = group,
                admins = repo.iRashaka<GroupUser>().GetAll(x => x.groupId == group.id && x.isAdmin == true),
                //usersCount =group.acceptedMembersCount /*repo.iRashaka<GroupUser>().Count(x => x.groupId == group.id)*/,
                //postsCount =group.postsCount,// repo.iRashaka<GroupPost>().Count(x => x.groupId == group.id),
                //eventsCount =group.eventsCount,// repo.iRashaka<GroupEvent>().Count(x => x.groupId == group.id),
                reportsCount = repo.iRashaka<GroupReport>().Count(x => x.groupId == group.id),

                postsReportsCount = group.reportsCount// repo.iRashaka<GroupPostReport>().Count(x => x.GroupPost.groupId == group.id)
            };
            return model;
            }
            return null;
        }
    }
}