using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using RashakaGroupsAdmin.Requests;
using X.PagedList;
using System.Text.Json;
namespace RashakaGroupsAdmin.Services
{
    public class GroupsService : IGroupsService
    {
        IRashakaUniteOfWork repo;
        IAdminUsers iAdminUsers;
        readonly IHttpContextAccessor _httpContextAccessor;
        public GroupsService(IRashakaUniteOfWork _repo, IAdminUsers _iAdminUsers, IHttpContextAccessor httpContextAccessor)
        {
            repo = _repo;
            iAdminUsers = _iAdminUsers;
            _httpContextAccessor = httpContextAccessor;
        }
        public GroupsDetailsModel GetGroupDetails(int id)
        {
            var groupUser = DapperService<GroupUser>.Query("select accountId,allstepsCount,[monthStepsCount],[weekStepsCount],[allDistance],[monthDistance],[weekDistance],[lastUploadDate]  from groupusers where groupid=" + id + "");
            var topFiveAccountIds = groupUser.Where(x => x.lastUploadDate >= DateTime.Now.AddDays(-7) /*&& x.lastUploadDate <= DateTime.Now*/).OrderByDescending(x => x.weekStepsCount).Take(6).Select(m => m.accountId).Cast<Int32>().ToList();
            if (topFiveAccountIds.Count <= 0)
            {
                topFiveAccountIds = groupUser.OrderByDescending(x => x.allStepsCount).Take(6).Select(m => m.accountId).Cast<Int32>().ToList();
            }
            //var allSteps = groupUser.Sum(x => (long?)x.allStepsCount);
            //var averageWeekSteps = groupUser.Average(x => x.weekStepsCount);
            //var averageWeekDistance = groupUser.Average(x => x.weekDistance);
            //var allDistance = groupUser.Sum(x => (long?)x.allDistance);
            var userOfTheWeek = repo.iRashaka<Account>().Find(topFiveAccountIds.FirstOrDefault());

            return new GroupsDetailsModel
            {
                group = repo.iRashaka<Group>().GetByIncluding(x => x.id == id, "typeNavigation"),
                allSteps = groupUser.Sum(x => (long?)x.allStepsCount) ?? 0,
                totalWeekSteps = groupUser.Where(x => x.lastUploadDate >= DateTime.Now.AddDays(-7)).Sum(x => x.weekStepsCount) ?? 0,
                totalWeekDistance = groupUser.Where(x => x.lastUploadDate >= DateTime.Now.AddDays(-7)).Sum(x => x.weekDistance) ?? 0,
                averageWeekSteps = groupUser.Where(x => x.lastUploadDate >= DateTime.Now.AddDays(-7)).Average(x => x.weekStepsCount) ?? 0,
                averageWeekDistance = groupUser.Where(x => x.lastUploadDate >= DateTime.Now.AddDays(-7)).Average(x => x.weekDistance) ?? 0,
                allDistance = groupUser.Sum(x => (long?)x.allDistance) ?? 0,
                TopFiveAccounts = repo.iRashaka<Account>().GetAll(x => topFiveAccountIds.Contains(x.id)).ToList(),
                TopWeekAccount = userOfTheWeek != null ? new Account { name = userOfTheWeek.name, weekStepsCount = userOfTheWeek.weekStepsCount, image = ImagesSevice.GetProfileImageUrl(userOfTheWeek.image) } : new Account { name = "لا يوجد", image = "" }
            };
        }
        public GroupStepsModel GetGroupSteps(int id)
        {
            //var steps = GetGroupStepsByPeriod(id);
            var today = DateTime.Today;
            var yearStart = new DateTime(today.Year, 1, 1);
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);
            var lastMonthStart = monthStart.AddMonths(-1);
            var lastMonthEnd = monthStart.AddDays(-1);
            DateTime firstDayOfWeek = FirstDayOfWeek(DateTime.Now);

            var yearSteps = GetGroupStepsByYearMonths(id);
            var dailySteps = GetGroupStepsByWeekDays(id);
            var monthSteps = GetGroupStepsByMonthDays(id);
            //var yearSteps = steps.Where(x => x.date >= yearStart).GroupBy(x => x.date.Value.Month).Select(x => new StepModel { count = x.Sum(m => m.count), date = x.First().date }).ToList();
            //var monthSteps = steps.Where(x => x.date >= monthStart).GroupBy(x => x.date).Select(x => new StepModel { count = x.Sum(m => m.count), date = x.First().date }).ToList();
            //var dailySteps = steps.Where(x => x.date >= firstDayOfWeek).GroupBy(x => x.date).Select(x => new StepModel { count = x.Sum(m => m.count), date = x.First().date }).ToList();

            //var yearDistance = steps.Where(x => x.date >= yearStart).GroupBy(x => x.date.Value.Month).Select(x => new StepModel { distance = x.Sum(m => m.distance), date = x.First().date }).ToList();
            //var monthDistance = steps.Where(x => x.date >= monthStart).GroupBy(x => x.date).Select(x => new StepModel { distance = x.Sum(m => m.distance), date = x.First().date }).ToList();
            //var dailyDistance = steps.Where(x => x.date >= firstDayOfWeek).GroupBy(x => x.date).Select(x => new StepModel { distance = x.Sum(m => m.distance), date = x.First().date }).ToList();

            return new GroupStepsModel
            {
                monthSteps = monthSteps,
                dailySteps = dailySteps,
                yearSteps = yearSteps,
                yearDistance = yearSteps,
                monthDistance = monthSteps,
                dailyDistance = dailySteps
            };
        }
        public DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff - 1).Date;
        }
        public int AddGroup(GroupModel group)
        {
            Group _group = new Group
            {
                privacyId = group.privacyId,
                privacy = group.privacyId == 1 ? "opened" : "closed",
                iso = group.iso ?? "",
                typeId = group.typeId,
                name = group.name,
                description = group.description ?? "",
                creatorId = iAdminUsers.GetLoggedUserId(),
                coverImage = group.coverImage != null ? "" : "defaultGroupCover"
            };
            string jsonData = JsonSerializer.Serialize(_group);
            HttpClient _httpclient = new HttpClient();
            using (var multiPartStream = new MultipartFormDataContent())
            {
                multiPartStream.Add(new StringContent(jsonData), "data");
                var files = _httpContextAccessor.HttpContext.Request.Form.Files;

                var file1 = group.image;
                var file2 = group.coverImage;
                if (file1 != null)
                {
                    multiPartStream.Add(new StreamContent(file1.OpenReadStream()), "image", file1.FileName);
                }
                if (file2 != null)
                {
                    multiPartStream.Add(new StreamContent(file2.OpenReadStream()), "cover", file2.FileName);
                }


                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/api/Groups/AddGroup");
                request.Content = multiPartStream;
                HttpCompletionOption option = HttpCompletionOption.ResponseContentRead;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                using (HttpResponseMessage response = _httpclient.SendAsync(request, option).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        dynamic resultJson = JsonSerializer.Deserialize<dynamic>(result.ToString());
                        var id = resultJson["id"];
                        //var deserializedObject = JsonConvert.DeserializeObject<object>(result);
                        //dynamic data = JArray.Parse(result.ToString());
                        return (Int32)id;// deserializedObject.postId;
                    }
                    return 0;
                }
            }
        }
        public int EditGroup(GroupModel model)
        {
            //Group _group = GetGroup(model.id);
            Group _group = new Group
            {
                id = model.id,
                privacyId = model.privacyId,
                privacy = model.privacyId == 1 ? "opened" : "closed",
                iso = model.iso ?? "",
                typeId = model.typeId,
                name = model.name,
                description = model.description ?? "",
                creatorId = iAdminUsers.GetLoggedUserId(),
                coverImage = ""
            };

            string jsonData = JsonSerializer.Serialize(_group);

            HttpClient _httpclient = new HttpClient();
            using (var multiPartStream = new MultipartFormDataContent())
            {
                multiPartStream.Add(new StringContent(jsonData), "data");
                var files = _httpContextAccessor.HttpContext.Request.Form.Files;

                var file1 = model.image;
                var file2 = model.coverImage;
                if (file1 != null)
                {
                    multiPartStream.Add(new StreamContent(file1.OpenReadStream()), "image", file1.FileName);
                }
                if (file2 != null)
                {
                    multiPartStream.Add(new StreamContent(file2.OpenReadStream()), "cover", file2.FileName);
                }


                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://api.rashaqa.net/api/Groups/EditGroup");
                request.Content = multiPartStream;
                HttpCompletionOption option = HttpCompletionOption.ResponseContentRead;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                using (HttpResponseMessage response = _httpclient.SendAsync(request, option).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        dynamic resultJson = JsonSerializer.Deserialize<dynamic>(result.ToString());
                        var id = resultJson["id"];
                        //var deserializedObject = JsonConvert.DeserializeObject<object>(result);
                        //dynamic data = JArray.Parse(result.ToString());
                        return (Int32)id;// deserializedObject.postId;
                    }
                    return 0;
                }
            }
        }
        public void DeleteGroup(int groupId)
        {
            Group group = repo.iRashaka<Group>().Find(groupId);
            if (groupId != 4)
            {
                group.isDeleted = true;
                repo.Save();
            }
        }
        private IEnumerable<StepModel> GetGroupStepsByYearMonths(int groupId)
        {
            var today = DateTime.Today;
            var yearStart = new DateTime(today.Year, 1, 1);
            var yearEnd = new DateTime(today.Year, DateTime.Now.Month, today.Day);
            return DapperService<StepModel>.Query("select sum([count]+0.0) as steps,sum(distance+0.0) as distance,month([date]) as [month] from steps where accountId in   ( select  accountid from groupusers where groupid=" + groupId + " and joindate<='" + DateTime.Now.Date + "') and  date>='" + yearStart + "' and date<='" + yearEnd + "' and typeid<3 group by month([date])");
        }
        private IEnumerable<StepModel> GetGroupStepsByWeekDays(int groupId)
        {
            DateTime firstDayOfWeek = FirstDayOfWeek(DateTime.Now);
            return DapperService<StepModel>.Query("select sum([count]+0.0) as steps,sum(distance+0.0) as distance,[date] from steps where accountId in  ( select  accountid from groupusers where groupid=" + groupId + " and joindate<='" + DateTime.Now.Date + "') and  date>='" + firstDayOfWeek + "' and date<='" + DateTime.Now.Date + "' and typeid<3 group by [date]");
        }
        private IEnumerable<StepModel> GetGroupStepsByMonthDays(int groupId)
        {
            var today = DateTime.Today;
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);
            return DapperService<StepModel>.Query("select sum([count]+0.0) as steps,sum(distance+0.0) as distance,Day([date]) as [day] from steps where accountId in   ( select  accountid from groupusers where groupid=" + groupId + " and joindate<='" + DateTime.Now.Date + "') and  date>='" + monthStart + "' and date<='" + monthEnd + "' and typeid<3 group by Day([date])");
        }
        public IEnumerable<Group> GetUserGroups(int accountId)
        {
            var groups = DapperService<Group>.Query("select g.id,g.typeid,g.name,g.date,g.privacy,g.image,g.acceptedMembersCount from [dbo].[Groups] g join [dbo].[GroupUsers] gu on g.id=gu.groupId where isAdmin=1 and g.isdeleted IS NULL and gu.accountId=" + accountId + "");

            return groups;
        }
        public static IEnumerable<string> GetGroupUsersImages(int groupId)
        {
            var images = DapperService<Account>.Query("SELECT TOP 5 [image]  FROM dbo.accounts ac  JOIN dbo.GroupUsers gu   ON ac.id = gu.accountid 	where groupId=" + groupId + " and ac.image!=''	order by gu.id desc ");
            foreach (var item in images)
            {
                item.image = ImagesSevice.GetProfileImageUrl(item.image);
            }
            //images.f(x => ImagesSevice.GetProfileImageUrl(x));
            return images.Select(x => x.image);
        }
        public IEnumerable<Group> GetUserGroups(int accountId, string filter)
        {
            string command;
            switch (filter)
            {
                case "users": command = "select g.* from [dbo].[Groups] g join [dbo].[GroupUsers] gu on g.id=gu.groupId where isAdmin=1 and g.isdeleted IS NULL and gu.accountId=" + accountId + " order by acceptedMembersCount desc"; break;
                case "posts": command = "select g.* from [dbo].[Groups] g join [dbo].[GroupUsers] gu on g.id=gu.groupId where isAdmin=1 and g.isdeleted IS NULL and gu.accountId=" + accountId + " order by postsCount desc"; break;
                case "date": command = "select g.* from [dbo].[Groups] g join [dbo].[GroupUsers] gu on g.id=gu.groupId where isAdmin=1 and g.isdeleted IS NULL and gu.accountId=" + accountId + " order by g.date desc"; break;
                default:
                    command = "select g.* from [dbo].[Groups] g join [dbo].[GroupUsers] gu on g.id=gu.groupId where isAdmin=1 and g.isdeleted IS NULL and gu.accountId=" + accountId + "";
                    break;
            }
            return DapperService<Group>.Query(command);
        }
        public GroupSettingsModel GetGroupSettings(int id)
        {
            return new GroupSettingsModel
            {
                Group = repo.iRashaka<Group>().GetByIncluding(x=>x.id==id, "typeNavigation"),
                GroupAdmins = repo.iRashaka<GroupUser>().GetAll(x => x.groupId == id && x.isAdmin == true).Select(x => x.account).ToList()
            };
        }
        public string GetGroupName(int groupId)
        {
            return repo.iRashaka<Group>().Find(groupId).name;
        }
        public IPagedList<GroupReport> GetGroupReporting(int id, int page)
        {
            return repo.iRashaka<GroupReport>().GetAll(x => x.groupId == id, x => x.id, page, 10, "group,account");
        }
        public Group GetGroup(int id)
        {
            return repo.iRashaka<Group>().Find(id);
        }
       
        public static async Task<int> AddEditGroupEvent(string url, string JsonData, IFormFile image)
        {

            HttpClient _httpclient = new HttpClient();
            using (var multiPartStream = new MultipartFormDataContent())
            {
                multiPartStream.Add(new StringContent(JsonData), "data");

                if (image != null)
                {
                    multiPartStream.Add(new StreamContent(image.OpenReadStream()), "image", image.FileName);
                }

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = multiPartStream;
                HttpCompletionOption option = HttpCompletionOption.ResponseContentRead;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                using (HttpResponseMessage response = _httpclient.SendAsync(request, option).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        dynamic jsonData = JsonSerializer.Deserialize<dynamic>(result.ToString());
                        var id = jsonData["id"];
                        //var deserializedObject = JsonConvert.DeserializeObject<object>(result);
                        //dynamic data = JArray.Parse(result.ToString());
                        return (Int32)id;// deserializedObject.postId;
                    }
                    return 0;
                }
            }
        }

      
        public static async Task<int> AddEditGroupPost(string url, GroupPostEdit groupPostEdit, IFormFile image, IFormFile image2, IFormFile image3)
        {
            if (groupPostEdit.groupId == 5698) //مجموعه هى لنا دار
            {
                groupPostEdit.accountId = 1940163;
            }
            string jsonData = JsonSerializer.Serialize(groupPostEdit);
            HttpClient _httpclient = new HttpClient();
            using (var multiPartStream = new MultipartFormDataContent())
            {
                multiPartStream.Add(new StringContent(jsonData), "data");

                if (image != null)
                {
                    multiPartStream.Add(new StreamContent(image.OpenReadStream()), "image", image.FileName);
                }
                if (image2 != null)
                {
                    multiPartStream.Add(new StreamContent(image2.OpenReadStream()), "image2", image2.FileName);
                }
                if (image3 != null)
                {
                    multiPartStream.Add(new StreamContent(image3.OpenReadStream()), "image3", image3.FileName);
                }

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = multiPartStream;
                HttpCompletionOption option = HttpCompletionOption.ResponseContentRead;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                using (HttpResponseMessage response = _httpclient.SendAsync(request, option).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        dynamic resultJson = JsonSerializer.Deserialize<dynamic>(result.ToString());
                        var id = resultJson["postId"];
                        //var deserializedObject = JsonConvert.DeserializeObject<object>(result);
                        //dynamic data = JArray.Parse(result.ToString());
                        return (Int32)id;// deserializedObject.postId;
                    }
                    return 0;
                }
            }
        }

        public void ReadNotification(int id)
        {
            DapperService<object>.ExecuteQuery("update [GroupUserNotifications] set isRead=1 where id=@id", new { id });
        }
    }
}