using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresGitHub.Controllers
{

    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();

        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.MyData = myQueue; //needed here to prevent errors when rendering
            ViewBag.Message = "Represents a first-in, first-out (FIFO) collection of objects.";

            return View();
        }

        public ActionResult AddOne() //adds one item to the data structure
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));

            ViewBag.MyData = myQueue;
            ViewBag.Message = "One item added to Queue";

            return View("Index");
        }

        public ActionResult AddHuge() //adds a list of 2,000 items to data structure
        {
            myQueue.Clear();

            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));

                ViewBag.MyData = myQueue;
                ViewBag.Message = "2,000 items added to Queue";
            }

            return View("Index");
        }

        public ActionResult Display() //display the data structure on screen
        {
            ViewBag.MyData = myQueue;
            ViewBag.Message = "Queue successfully displayed";

            return View("Index");
        }

        public ActionResult Delete() //removes one item from data structure
        {
            ViewBag.MyData = myQueue;

            if (myQueue.Count > 0) //error handling for empty data structures
            {
                ViewBag.Message = "'" + myQueue.Dequeue() + "' deleted from Queue";
            }
            else
            {

                ViewBag.Message = "No item to delete from Queue";
            }

            return View("Index");
        }

        public ActionResult Clear() //empty out the data structure
        {
            if (myQueue.Count > 0) //error handling for empty data structures
            {
                ViewBag.Message = "Queue cleared";
            }
            else
            {
                ViewBag.Message = "Queue already empty";
            }

            myQueue.Clear();
            ViewBag.MyData = myQueue;

            return View("Index");
        }

        public ActionResult Search()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start(); //start timer

            ViewBag.Message = "Queue was searched for 'New Entry 1000'. Results are: " + myQueue.Contains("New Entry 1000");

            timer.Stop(); //stop timer
            ViewBag.MyData = myQueue;
            ViewBag.Stopwatch = "Completed in " + timer.Elapsed + " seconds";

            return View("Index");
        }
    }
}