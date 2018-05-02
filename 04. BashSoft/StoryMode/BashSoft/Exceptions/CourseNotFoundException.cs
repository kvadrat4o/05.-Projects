using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    class CourseNotFoundException : Exception
    {
        private const string InvalidCourse = "Student must be enrolled in a course before you set his mark.";

        public CourseNotFoundException():base(InvalidCourse)
        {

        }

        public CourseNotFoundException(string message) :base(message)
        {

        }
    }
}
