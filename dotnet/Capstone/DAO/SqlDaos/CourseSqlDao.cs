using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class CourseSqlDao : ICourseDao
    {
        private readonly string connectionString;
        public CourseSqlDao(string dbConnectionString)
        {
            this.connectionString = dbConnectionString;
        }
        public Course CreateCourse(Course course)
        {
            int newCourseId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO courses(course_name)
                                                OUTPUT INSERTED.course_id
                                                VALUES (@course_name)", conn);
                    cmd.Parameters.AddWithValue("@course_name", course.CourseName);

                    newCourseId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                course.CourseId = newCourseId;
                return course;
            }
            catch (SqlException)
            {
                throw;
            }
        }

    }
}
