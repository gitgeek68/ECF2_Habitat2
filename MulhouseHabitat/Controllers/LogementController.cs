using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MulhouseHabitat.Models;
using System.IO;

namespace MulhouseHabitat.Controllers
{
    public class LogementController : Controller
    {

        Dal dal;

        public LogementController()
        {
            dal = new Dal();
        }

        public ActionResult Index()
        {
            return View(dal.GetLogements());
        }


        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(MHLogements logements)
        {
            bool isCorrect = false;
            for (int i = 0; i < GetLogements.Count; i++)
            {
                if (logements.Id == dal.GetLogements[i].Count)//egale au predicat en dessous
                {
                    isCorrect = true;

                }

            }
            if (isCorrect == false)
            {
                //Produits.Add(p);
                dal.GetLogements(logements);

            }
            return RedirectToAction("Index");//redirection vers la vue index
        }

        public ActionResult Detail (string id)
        {
            MHLogements l = dal.GetLogement(id);
        }
    }
}