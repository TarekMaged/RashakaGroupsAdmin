using RashakaGroupsAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RashakaGroupsAdmin.Repository.Interfaces
{
    public interface ILogin
    {
        bool Login(Login adminDatat);
    }
}
