using Microsoft.AspNetCore.Mvc;
using mitesh_gandhi_pratical_test.Interface;
using mitesh_gandhi_pratical_test.Models;

namespace mitesh_gandhi_pratical_test.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPerson _person;
        public PersonController(IPerson person) 
        { 
            _person = person;
        }
        public IActionResult Index()
        {
            var data = _person.GetPeoples();
            return View(data);
        }
        [HttpPost]
        public IActionResult AddOrUpdatePerson(PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                if (personModel.Id == 0)
                {
                    _person.AddPerson(personModel);
                }
                else
                {
                    _person.UpdatePerson(personModel);
                }
                return RedirectToAction(nameof(Index));
            }
            return BadRequest(ModelState);

        }
        [HttpGet]
        public IActionResult GetPeopleById(int Id)
        {
            var data = _person.GetPeopleById(Id);
            return Json(data);
        }
        public IActionResult DeletePeople(int Id)
        {
            _person.DeletePerson(Id);
            return RedirectToAction(nameof(Index));
        }
       
       
    }
}
