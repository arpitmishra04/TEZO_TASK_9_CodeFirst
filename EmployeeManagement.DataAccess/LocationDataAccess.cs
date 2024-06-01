using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class LocationDataAccess:ILocationDataAccess
    {
        public void Build()
        {
            TinyMapper.Bind<LocationEntity, LocationModel>(config =>
            {
                config.Ignore(x => x.LocationEntityId);
                

            });
            TinyMapper.Bind<LocationModel, LocationEntity>();
        }
        

        public List<LocationModel> GetAll()
        {
            Build();
            List<LocationModel> locations = [];
            List<LocationEntity> locs = [];
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
                locs=context.Locations.ToList();

                foreach (LocationEntity loc in locs)
                {
                    LocationModel location = TinyMapper.Map<LocationModel>(loc);
                    locations.Add(location);

                }
                context.SaveChanges();
            }

             return locations;

        }

        public bool Set(LocationModel location)
        {
            Build();
            using (var context=new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
                LocationEntity loc = TinyMapper.Map<LocationEntity>(location);
                context.Locations.Add(loc);
                context.SaveChanges();

                

            }

               
            return true;
        }
    }
}
