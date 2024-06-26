﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;

namespace EmployeeManagement.Core.Services
{
    public class RoleService : IRoleService
    {
        private IRoleDataAccess roleDataAccess;
        public RoleService(IRoleDataAccess _roleDataAccess) { 
            this.roleDataAccess = _roleDataAccess;
        }
        public void Build()
        {

            TinyMapper.Bind<RoleEntity, RoleModel>(config =>
            {
                config.Ignore(x => x.RoleEntityId);


            });
            TinyMapper.Bind<RoleModel, RoleEntity>();
        }
        public bool Add(RoleModel role)
        {

            Build();
            RoleEntity roleData = TinyMapper.Map<RoleEntity>(role);
            return roleDataAccess.Set(roleData);
        }

        public List<RoleModel> ViewAll()
        {
            Build();
            List<RoleEntity> roleDataList = roleDataAccess.GetAll();
            List<RoleModel> roles = new List<RoleModel>();

            foreach (RoleEntity role in roleDataList)
            {
                roles.Add(TinyMapper.Map<RoleModel>(role));
            }
            return roles;
        }
    }
}
