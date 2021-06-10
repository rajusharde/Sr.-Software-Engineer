using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Web_Application.Code.IRepository;

namespace Test_Web_Application.Code.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        private TestDbContext context;
        private DbSet<Designation> designationEntity;
        public DesignationRepository(TestDbContext context)
        {
            this.context = context;
            designationEntity = context.Set<Designation>();
        }


        public void SaveDesignation(Designation designation)
        {
            context.Entry(designation).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Designation> GetAllDesignations()
        {
            return designationEntity.AsEnumerable();
        }

        public Designation GetDesignation(int id)
        {
            return designationEntity.SingleOrDefault(s => s.DesignationId == id);
        }
        public void DeleteDesignation(int id)
        {
            Designation designation = GetDesignation(id);
            designationEntity.Remove(designation);
            context.SaveChanges();
        }
        public void UpdateDesignation(Designation designation)
        {
            context.SaveChanges();
        }

    }
}
 