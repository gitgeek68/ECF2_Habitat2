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

        static public List<MHLogements> logements = new List<MHLogements>()
        {

        };

        public ActionResult Index()
        {
            return View(dal.GetLogements());
        }




        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(MHLogements p)
        {
            bool isCorrect = false;
            for (int i = 0; i < logements.Count; i++)
            {
                if (p.Id == logements[i].Id)//egale au predicat en dessous
                {
                    isCorrect = true;

                }

            }
            if (isCorrect == false)
            {
                //Produits.Add(p);
                dal.AddLogement(p);

            }
            return RedirectToAction("Index");//redirection vers la vue index
        }




        public ActionResult Details(MHLogements id)
        {
            MHLogements p = dal.GetLogement(id);
            //Product p = Produits.FirstOrDefault(x=>(x.Reference == id));
            /*le predicat au dessus recupere le produit dans la liste */

            if (p != default(MHLogements))//si different du produit par defaut
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(MHLogements id)
        {
            MHLogements p = dal.GetLogement(id);
            //retourne un produit par reference
            //Product p = Produits.FirstOrDefault(x => (x.Reference == id));

            if (p != default(MHLogements))//si different du produit par defaut
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditConfirmed(MHLogements _p)
        {
            MHLogements exist = dal.GetLogement(_p);

            //Product exist = Produits.FirstOrDefault(x => (x.Reference == _p.Reference));
            if (exist != default(MHLogements))
            {
                _p.Id = exist.Id;
                dal.UpdateLogement(_p);

                //recupere le produit par reference et verifie s il exist


            }
            return RedirectToAction("Index");
        }



    }

}