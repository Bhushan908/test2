using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.DB.DBOperations
{
    public class StudentRepository
    {
        public int AddStudent(StudentModel model)
        {
            using (var context = new StudentDBMVCEntities())
            {
                studentinfor std = new studentinfor()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Age = model.Age,
                    Class = model.Class
                };

                context.studentinfor.Add(std);

                context.SaveChanges();

                return std.Id;
            }
        }

        public List<StudentModel> GetAllStudent()
        {
            using (var context = new StudentDBMVCEntities())
            {
                var result = context.studentinfor
                    .Select(x => new StudentModel()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        Class = x.Class,
                        Age = x.Age

                    }).ToList();
                return result;
            }
        }

        public StudentModel GetStudent(int id)
        {
            using (var context = new StudentDBMVCEntities())
            {
                var result = context.studentinfor
                    .Where(x =>x.Id==id )
                    .Select(x => new StudentModel()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        Class = x.Class,
                        Age = x.Age

                    }).FirstOrDefault();
                return result;
            }
        }

        public bool UpdateStudent(int id,StudentModel model)
        {
            using (var context = new StudentDBMVCEntities())
            {
                var student = new studentinfor();
                {
                    if(student != null)
                    {
                        student.FirstName = model.FirstName;
                        student.LastName = model.LastName;
                        student.Email = model.Email;
                        student.Class = model.Class;
                        student.Age = model.Age;
                    }
                    context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public bool DeleteStudent(int id)
        {
            using (var context = new StudentDBMVCEntities())
            {
                var std = new studentinfor()
                {
                    Id = id
                };
                context.Entry(std).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return false;
            }
        }
    }
}
