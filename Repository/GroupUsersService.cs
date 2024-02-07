using AutoMapper.Execution;
using Microsoft.Identity.Client;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using RashakaGroupsAdmin.Requests;
using RashakaGroupsAdmin.Services;
using RashakaGroupsAdmin.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text.Json;
using Group = RashakaGroupsAdmin.Models.Group;

namespace RashakaGroupsAdmin.Repository
{
    public class GroupUsersService : IGroupUser
    {
        IRashakaUniteOfWork repo;
        IAdminUsers iAdminUsers;
        public GroupUsersService(IRashakaUniteOfWork _repo, IAdminUsers _iAdminUsers)
        {
            this.repo = _repo;
            this.iAdminUsers = _iAdminUsers;
        }
        public string UpdateProfileImage(IFormFile image)
        {
            int accountId = iAdminUsers.GetLoggedUserId();
            string jsonData = JsonSerializer.Serialize(new { accountId });
            HttpClient _httpclient = new HttpClient();
            using (var multiPartStream = new MultipartFormDataContent())
            {
                multiPartStream.Add(new StringContent(jsonData), "data");
                if (image != null)
                {
                    multiPartStream.Add(new StreamContent(image.OpenReadStream()), "image", image.FileName);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://api.rashaqa.net/api/users/UpdateProfileImage");
                    request.Content = multiPartStream;
                    HttpCompletionOption option = HttpCompletionOption.ResponseContentRead;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                    using (HttpResponseMessage response = _httpclient.SendAsync(request, option).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            dynamic resultJson = JsonSerializer.Deserialize<dynamic>(result.ToString());
                            var id = resultJson["imageURL"];
                            return id;// deserializedObject.postId;
                        }
                        return "";
                    }
                }
                return "";
            }
        }

        public IEnumerable<Account> GetMembers(int groupId, string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                return DapperService<Account>.Query(" select   top 10 ac.id,ac.name"
           + " from [GroupUsers] gu join accounts ac on gu.accountid = ac.id   where gu.groupid = " + groupId + " and ac.name like '" + key + "%' and requestStatus='accepted' order by ac.id desc");

            }
            return DapperService<Account>.Query(" select   top 10 ac.id,ac.name"
           + " from [GroupUsers] gu join accounts ac on gu.accountid = ac.id   where gu.groupid = " + groupId + " and requestStatus='accepted' order by ac.id desc");
        }

        public object GetUsersSteps(int groupId)
        {
            GroupSteps steps = new GroupSteps
            {
                groupId = groupId,
                accountId = 0,
                page = 1,
                period = "week",
                todayDate = DateTime.Now
            };
            return GetResponseFromCommentSystem(JsonSerializer.Serialize(steps));
        }




        public object GetResponseFromCommentSystem(string json)
        {
            dynamic resultJosn;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.rashaqa.net/api/Groups/GetGroupSteps");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    resultJosn = JsonSerializer.Deserialize<dynamic>(streamReader.ReadToEnd());
                }
                return resultJosn;
            }
            catch
            {
                return "";
            }

        }

        public object GetUsersProfile(int accountId, string accountGuid, int groupId)
        {

            Account account = GetAccount(accountId, accountGuid);

            var groupUser = repo.iRashaka<GroupUser>().GetAll(x => x.accountId == account.id && x.groupId == groupId, "group").FirstOrDefault();

            var posts = repo.iRashaka<GroupPost>().GetAll(x => x.accountId == account.id && x.groupId == groupId, x => x.id, 1, 15);
            var group = groupUser.group;
            return new UserProfileModel
            {
                GroupId = groupId,
                GroupName = groupUser.group.name,
                CretatorId = group.creatorId ?? 0,
                Account = account,
                UserPosts = posts,
                GroupUser = groupUser
            };
        }
        Account GetAccount(int accountId, string accountGuid)
        {
            Account account;
            if (accountId > 0)
            {
                account = DapperService<Account>.Query("select id,name,gender,email,image from accounts where id=@id", new { id = accountId }).FirstOrDefault();
            }
            else
            {
                account = DapperService<Account>.Query("select id,name,gender,email,image from accounts where guid=@guid", new { guid = accountGuid }).FirstOrDefault();
            }
            account.image = ImagesSevice.GetProfileImageUrl(account.image);
            return account;
        }
        public Group GetGroup(int id)
        {
            return repo.iRashaka<Group>().Find(id);
        }
        public GroupMembersModel GetGroupMemebers(int groupId, string period, int page)
        {
            period = string.IsNullOrWhiteSpace(period) ? "today" : period;
            IEnumerable<MembersModel> members;
            switch (period)
            {
                case "all":
                    members = GetTotalSteps(groupId, page); break;
                case "week":
                    members = GetWeekSteps(groupId, page); break;
                case "month":
                    members = GetMonthSteps(groupId, page); break;
                case "yesterday":
                    members = GetYesterdaySteps(groupId, page); break;
                default:
                    members = GetTodaySteps(groupId, page); break;
            }
            members.Where(x => x.Steps == 0).ToList().ForEach(x => x.Distance = 0);

            var group = repo.iRashaka<Group>().Find(groupId); 
            GroupMembersModel membersModel = new GroupMembersModel
            {

                Memebers = members,
                page = page,
                period = period,
                GroupId = groupId,
                GroupName = group.name,
                creatorId = group.creatorId,
                NotActiveFilter= FilterItems.filters.Where(x => x.filter != period).ToList(),
                ActiveFilter = FilterItems.filters.Where(x => x.filter == period).FirstOrDefault()
            };           
         

            return membersModel;
        }

        public IEnumerable<MembersModel> GetTodaySteps(int? groupId, int page)
        {
            return DapperService<MembersModel>.Query(" select   ac.id,ac.name,ac.email,ac.image,ac.gender,gu.joindate,"
                + "steps=case when gu.[currentDayDate]=cast(getdate() as date) then gu.[currentDayStepsCount] else 0 end,"
                + "distance=gu.[todayDistance],"
                + "gu.[currentDayDate],isAdmin  from [GroupUsers] gu join accounts ac on gu.accountid = ac.id   where groupid = " + groupId + " order by steps desc OFFSET(" + page + " - 1) *10 ROWS FETCH NEXT 10 ROWS ONLY");
        }

        public IEnumerable<MembersModel> GetYesterdaySteps(int? groupId, int page)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            return DapperService<MembersModel>.Query(" select   ac.id,ac.name,ac.email,ac.image,ac.gender,gu.joindate,"
           + "steps=case when gu.[yesterdayDate]='" + yesterday.Date.ToString("dd-MM-yyyy") + "' then gu.[yesterdayStepsCount] else 0 end,"
         + "distance=gu.[yesterdayDistance],"
           + " gu.[yesterdayDate],isAdmin  from [GroupUsers] gu join accounts ac on gu.accountid = ac.id   where groupid = " + groupId + " order by steps desc OFFSET(" + page + " - 1) *10 ROWS FETCH NEXT 10 ROWS ONLY");
        }
        public IEnumerable<MembersModel> GetWeekSteps(int? groupId, int page)
        {
            DateTime startDate = DateTime.Now.AddDays(-7);
            return DapperService<MembersModel>.Query("select   ac.id,ac.name,ac.email,ac.image,ac.gender,gu.joindate,"
                + "steps=case when gu.[lastUploadDate]>='" + startDate.Date.ToString("dd-MM-yyyy") + "' and gu.[lastUploadDate]<='" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "' then gu.[weekStepsCount] else 0 end,"
               + "gu.weekDistance as distance,   gu.[lastUploadDate] ,isAdmin from  [GroupUsers] gu join  accounts ac on gu.accountid = ac.id   where groupid = " + groupId + " order by steps desc OFFSET(" + page + " - 1) *10 ROWS FETCH NEXT 10 ROWS ONLY");

        }
        public IEnumerable<MembersModel> GetMonthSteps(int? groupId, int page)
        {
            DateTime startDate = DateTime.Now.AddDays(-30);
            return DapperService<MembersModel>.Query(" select   ac.id,ac.name,ac.email,ac.image,ac.gender,gu.joindate, steps=case when gu.[lastUploadDate]>='" + startDate.Date.ToString("dd-MM-yyyy") + "' and gu.[lastUploadDate]<='" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "' then gu.[monthStepsCount]"
           + "else 0 end, gu.monthDistance as distance  ,gu.[lastUploadDate] ,isAdmin from  [GroupUsers] gu join  accounts ac on gu.accountid = ac.id   where groupid = " + groupId + " order by steps desc OFFSET(" + page + " - 1) *10 ROWS FETCH NEXT 10 ROWS ONLY");
        }
        public IEnumerable<MembersModel> GetTotalSteps(int? groupId, int page)
        {
            return DapperService<MembersModel>.Query(" select   ac.id,ac.name,ac.email,ac.image,ac.gender,gu.joindate"
           + ",steps=gu.allstepsCount ,gu.allDistance as distance,isAdmin from  [GroupUsers] gu join  accounts ac on gu.accountid = ac.id   where groupid = " + groupId + " order by steps desc OFFSET(" + page + " - 1) *10 ROWS FETCH NEXT 10 ROWS ONLY");
        }



        public bool DeleteUser(int groupId, int accountId)
        {
            try
            {
                var user = repo.iRashaka<GroupUser>().GetBy(x => x.groupId == groupId && x.accountId == accountId);
                repo.iRashaka<GroupUser>().Delete(user);
                repo.Save();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool AssignOrDeleteAdmin(GroupUser item)
        {
            try
            {

                //GroupUser user = repo.iRashaka<GroupUser>().GetBy(x => x.accountId == item.accountId && x.groupId == item.groupId);
                //user.isAdmin = item.isAdmin;
                //repo.Save();
                //return true;
                string query = "update GroupUsers set isAdmin=0 where accountId=@accountId and groupId=@groupId;SELECT 1";

                if (item.isAdmin == true)
                {
                    query = "update GroupUsers set isAdmin=1 where accountId=@accountId and groupId=@groupId ;SELECT 1";
                }
                string res = DapperService<object>.ExecuteScalar(query, new { accountId = item.accountId, groupId = item.groupId }, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddAdminList(List<GroupUser> users)
        {
            try
            {
                foreach (var item in users)
                {
                    string query = "update GroupUsers set isAdmin=0 where accountId=@accountId and groupId=@groupId;SELECT 1";

                    if (item.isAdmin == true)
                    {
                        query = "update GroupUsers set isAdmin=1 where accountId=@accountId and groupId=@groupId ;SELECT 1";
                    }
                    string res = DapperService<object>.ExecuteScalar(query, new { accountId = item.accountId, groupId = item.groupId }, CommandType.Text).ToString();

                    //var groupUser = repo.iRashaka<GroupUser>().GetBy(x => x.groupId == item.groupId && x.accountId == item.accountId);
                    //groupUser.isAdmin = item.isAdmin;
                    //repo.Save();
                    //if (item.isAdmin == true && groupUser.isAdmin == false)
                    //{
                    //    //NotificationCenter.SendAfterAddGroupAdmins(groupUser);
                    //}
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Account> GetGroupAdmins(int groupId)
        {
            return DapperService<Account>.Query("select ac.id,ac.name from [GroupUsers] gu join accounts ac on gu.accountid = ac.id   where gu.groupid = " + groupId + " and isAdmin=1 and requestStatus='accepted' order by ac.id desc");
        }
    }
}