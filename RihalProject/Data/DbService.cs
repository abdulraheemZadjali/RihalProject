using RihalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalProject.Data
{
    public class DbService
    {
        protected readonly AppDbContext _db;

        public DbService(AppDbContext db)
        {
            _db = db;
        }

        //Get Lists
        public List<classes> GetClasses()
        {
            return _db.Classes.ToList();
        }
        public List<countries> GetCountries()
        {
            return _db.Countries.ToList();
        }
        public List<students> GetStudents()
        {
            var students = new List<students>();
            students = _db.Students.ToList();
            foreach(var item in students)
            {
                var country = _db.Countries.Where(i => i.Id == item.country_id).FirstOrDefault();
                item.country = country;
                var course = _db.Classes.Where(i => i.Id == item.class_id).FirstOrDefault();
                item.classes = course;
            }
            
            return students;
        }

        //Add
        public async Task<classes> AddClass(classes _class)
        {
            try 
            {
                _class.created_at = DateTime.Now;
                _db.Classes.Add(_class);
                await _db.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
                
            }
            return _class;
        }

        public async Task<countries> AddCountry(countries country)
        {
            try
            {
                country.created_at = DateTime.Now;
                _db.Countries.Add(country);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;

            }
            return country;
        }
        public async Task<students> AddStudent(students student)
        {
            try
            {
                student.created_at = DateTime.Now;
                _db.Students.Add(student);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;

            }
            return student;

        }

        //Update
        public async Task<classes> UpdateClass(classes _class)
        {
            try
            {
                var classExist = _db.Classes.FirstOrDefault(c => c.Id == _class.Id);
                if (classExist != null)
                {
                    _class.modified_at = DateTime.Now;
                    _db.Update(_class);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _class;
        }
        public async Task<countries> UpdateCountry(countries country)
        {
            try
            {
                var classExist = _db.Countries.FirstOrDefault(c => c.Id == country.Id);
                if (classExist != null)
                {
                    country.modified_at = DateTime.Now;
                    _db.Update(country);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return country;
        }
        public async Task<students> UpdateStudent(students student)
        {
            try
            {
                var classExist = _db.Students.FirstOrDefault(c => c.Id == student.Id);
                if (classExist != null)
                {
                    student.modified_at = DateTime.Now;
                    _db.Update(student);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return student;
        }

        //Remove
        public async Task DeleteClass(int class_id)
        {
            //Check if linked to student
            var student = _db.Students.Where(c => c.class_id == class_id).ToList();
            if (student.Count > 0)
            {
                
            }
            else 
            {
                try
                {
                    classes _class = _db.Classes.Where(c => c.Id == class_id).FirstOrDefault();
                    if (_class != null)
                    {
                        _db.Classes.Remove(_class);
                        await _db.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
        }
        public async Task DeleteCountry(int country_id)
        {
            try
            {
                countries country = _db.Countries.Where(c => c.Id == country_id).FirstOrDefault();
                if (country != null)
                {
                    _db.Countries.Remove(country);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteStudent(int student_id)
        {
            try
            {
                students student = _db.Students.Where(c => c.Id == student_id).FirstOrDefault();
                if (student != null)
                {
                    _db.Students.Remove(student);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Dashboard Stats
        public List<classes> StudentsPerClass()
        {
            var records = _db.Classes.ToList();
            foreach (var item in records)
            {
                var students = _db.Students.Where(c => c.class_id == item.Id).ToList();
                item.students = students;
            }

            return records;
        }
        public List<countries> StudentsPerCountry()
        {
            var records = _db.Countries.ToList();
            foreach (var item in records)
            {
                var students = _db.Students.Where(c => c.country_id == item.Id).ToList();
                item.students = students;
            }

            return records;
        }
    }
}
