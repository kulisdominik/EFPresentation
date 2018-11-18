using EF.Server.REST.Models;
using EF.Server.REST.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EF.Server.REST.Contexts
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
	    private IStudentRepository _studentRepository;

	    public StudentsController(IStudentRepository studentRepository)
	    {
		    _studentRepository = studentRepository;
	    }

		// GET api/students
		[HttpGet]
	    public ActionResult<IEnumerable<StudentModel>> Get()
	    {
		    IEnumerable<StudentModel> students = _studentRepository.Get();

		    if (students == null)
		    {
			    return NotFound(students);
			}

			return students.Count() > 0 ? 
				(ActionResult<IEnumerable<StudentModel>>)Ok(students) : 
				(ActionResult<IEnumerable<StudentModel>>)NotFound();
		}

		// GET api/students/5
		[HttpGet("{studentId}")]
	    public ActionResult<string> Get(int studentId)
	    {
		    StudentModel student = _studentRepository.Get(studentId);

		    if (student == null)
		    {
			    return NotFound();
		    }

		    return Ok(student);
		}

		// POST api/students
		[HttpPost]
	    public void Post([FromBody] StudentModel student)
	    {
		    _studentRepository.Insert(student);
		}

	    // PUT api/values/5
	    [HttpPut("{id}")]
	    public void Put([FromBody] StudentModel student)
	    {
		    _studentRepository.Update(student);
		}

	    // DELETE api/values/5
	    [HttpDelete("{id}")]
	    public void Delete(int studentId)
	    {
		    _studentRepository.Delete(studentId);
		}
	}
}