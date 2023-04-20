using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        private static List<EventModel> eventModels = new List<EventModel>()
        {
            new EventModel(){ id=1, name="first", location="location1"},
             new EventModel(){ id=2,name="second",location="location2"},
            new EventModel(){ id=3,name="third",location="location3"}
        };

        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult showevents() 
        {
            return View(eventModels); 
        }

        public ActionResult show_event(int id)
        {
            EventModel model = eventModels[id];
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEvent(EventModel model)
        {
            if(ModelState.IsValid==false)
                return View("newevent", model);
            else
            {
                model.id = eventModels.Count + 1;
                eventModels.Add(model);
                return View("show_event",model);
            }
           
        }
        public ActionResult newevent()
        {
            return View();
        }
        public ActionResult editevent(int id)
        { var model=eventModels.ElementAt(id);
            model.id=id;
            return View(model) ;
        }
        [HttpPost]
        public ActionResult editevent(EventModel model)
        { 
           if (ModelState.IsValid==false)
                return View("editevent",model);
            
            var forupdate=eventModels.ElementAt(model.id);
          forupdate.id=model.id+1;
            forupdate.name = model.name;
            forupdate.location = model.location;
            return  View("showevents", eventModels);
        }
        public ActionResult DeleteEvent (int id)
        { 
            eventModels.RemoveAt(id);
            return View("showevents", eventModels);
        }

    }
}