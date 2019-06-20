using _DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
    public class JobBusiness : DatabaseBusiness<JobApplication>
    {
        private MarketEntities db = new MarketEntities();
        public override void Create(JobApplication t)
        {
            db.JobApplications.Add(t);
            db.SaveChanges();
        }

        public override void Delete(JobApplication t)
        {
            db.JobApplications.Remove(t);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            JobApplication job = db.JobApplications.Find(id);
            db.JobApplications.Remove(job);
            db.SaveChanges();
        }

        public override List<JobApplication> List()
        {
            return db.JobApplications.ToList();
        }

        public override JobApplication Read(int id)
        {
            return db.JobApplications.SingleOrDefault(c => c.Id == id);

        }

        public override void Update(JobApplication t)
        {
            db.JobApplications.Attach(t);
            db.Entry<JobApplication>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
