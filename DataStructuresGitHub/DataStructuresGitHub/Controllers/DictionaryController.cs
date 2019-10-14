using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresGitHub.Controllers
{

    public class DictionaryController : Controller
    {
        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyData = myDictionary; //needed here to prevent errors when rendering
            ViewBag.Message = "Represents a collection of keys and values.";

            return View();
        }

        public ActionResult AddOne() //adds one item to the data structure
        {
            myDictionary.Add(myDictionary.Count + 1, "New Entry " + (myDictionary.Count + 1));

            ViewBag.MyData = myDictionary;
            ViewBag.Message = "One item added to Dictionary";

            return View("Index");
        }

        public ActionResult AddHuge() //adds a list of 2,000 items to data structure
        {
            myDictionary.Clear();

            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myDictionary.Add(myDictionary.Count + 1, "New Entry " + (myDictionary.Count + 1));

                ViewBag.MyData = myDictionary;
                ViewBag.Message = "2,000 items added to Dictionary";
            }

            return View("Index");
        }

        public ActionResult Display() //display the data structure on screen
        {
            ViewBag.MyData = myDictionary;
            ViewBag.Message = "Dictionary successfully displayed";

            return View("Index");
        }

        public ActionResult Delete() //removes one random item from data structure
        {
            ViewBag.MyData = myDictionary;

            if (myDictionary.Count > 0) //error handling for empty data structures
            {
                List<int> lKeys = new List<int>(); //error handling for non-contiguous keys

                foreach (int iKey in myDictionary.Keys) 
                {
                    lKeys.Add(iKey); //store each key into list
                }

                Random oRand = new Random(); 
                int iRand = oRand.Next(0, lKeys.Count - 1); //get random number of key to remove

                ViewBag.Message = "'" + myDictionary[lKeys[iRand]] + "' deleted from Dictionary";
                myDictionary.Remove(lKeys[iRand]);          
            }
            else
            {

                ViewBag.Message = "No item to delete from Dictionary";
            }

            return View("Index");
        }

        public ActionResult Clear() //empty out the data structure
        {
            if (myDictionary.Count > 0) //error handling for empty data structures
            {
                ViewBag.Message = "Dictionary cleared";
            }
            else
            {
                ViewBag.Message = "Dictionary already empty";
            }

            myDictionary.Clear();
            ViewBag.MyData = myDictionary;

            return View("Index");
        }

        public ActionResult Search()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start(); //start timer

            ViewBag.Message = "Dictionary was search for 'New Entry 1000'. Results are: " + myDictionary.ContainsKey(1000);

            timer.Stop(); //stop timer
            ViewBag.MyData = myDictionary;
            ViewBag.Stopwatch = "Completed in " + timer.Elapsed + " seconds";

            return View("Index");
        }
    }
}