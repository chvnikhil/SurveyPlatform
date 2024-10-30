using Microsoft.AspNetCore.Mvc;
using SurveyPlatform.BAL;
using SurveyPlatform.Models;

namespace SurveyPlatform.Controllers
{
    public class SurveyQuestionController : Controller
    {
        private readonly SurveyQuestionCoordinator _surveyQuestionBAL;

        public SurveyQuestionController()
        {
            _surveyQuestionBAL = new SurveyQuestionCoordinator();
        }

        // GET: SurveyQuestionController
        public ActionResult Index()
        {
            var surveyQuestions = _surveyQuestionBAL.GetAllSurveyQuestions();
            return View(surveyQuestions);
        }

        // GET: SurveyQuestionController/Details/5
        public ActionResult Details(int id)
        {
            var surveyQuestion = _surveyQuestionBAL.GetSurveyQuestionById(id);
            return View(surveyQuestion);
        }

        // GET: SurveyQuestionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyQuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyQuestion surveyQuestion)
        {
            try
            {
                _surveyQuestionBAL.CreateSurveyQuestion(surveyQuestion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SurveyQuestionController/Edit/5
        public ActionResult Edit(int id)
        {
            var surveyQuestion = _surveyQuestionBAL.GetSurveyQuestionById(id);
            return View(surveyQuestion);
        }

        // POST: SurveyQuestionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SurveyQuestion surveyQuestion)
        {
            try
            {
                _surveyQuestionBAL.UpdateSurveyQuestion(surveyQuestion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SurveyQuestionController/Delete/5
        public ActionResult Delete(int id)
        {
            var surveyQuestion = _surveyQuestionBAL.GetSurveyQuestionById(id);
            return View(surveyQuestion);
        }

        // POST: SurveyQuestionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _surveyQuestionBAL.DeleteSurveyQuestion(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
