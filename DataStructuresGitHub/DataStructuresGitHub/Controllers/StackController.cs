using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresGitHub.Controllers
{

    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyData = myStack; //needed here to prevent errors when rendering
            ViewBag.Message = "Represents a simple last-in-first-out (LIFO) non-generic collection of objects.";

            return View();
        }

        public ActionResult AddOne() //adds one item to the data structure
        {
            myStack.Push("New Entry " + (myStack.Count + 1));

            ViewBag.MyData = myStack;
            ViewBag.Message = "One item added to Stack";

            return View("Index");
        }

        public ActionResult AddHuge() //adds a list of 2,000 items to data structure
        {
            myStack.Clear();

            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));

                ViewBag.MyData = myStack;
                ViewBag.Message = "2,000 items added to Stack";
            }

            return View("Index");
        }

        public ActionResult Display() //display the data structure on screen
        {
            ViewBag.MyData = myStack;
            ViewBag.Message = "Stack successfully displayed";

            return View("Index");
        }

        public ActionResult Delete() //removes one item from data structure
        {
            ViewBag.MyData = myStack;

            if (myStack.Count > 0) //error handling for empty data structures
            {
                ViewBag.Message = "'" + myStack.Pop() + "' deleted from Stack";
            }
            else
            {

                ViewBag.Message = "No item to delete from Stack";
            }

            return View("Index");
        }

        public ActionResult Clear() //empty out the data structure
        {
            if (myStack.Count > 0) //error handling for empty data structures
            {
                ViewBag.Message = "Stack cleared";
            }
            else
            {
                ViewBag.Message = "Stack already empty";
            }

            myStack.Clear();
            ViewBag.MyData = myStack;

            return View("Index");
        }

        public ActionResult Search()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start(); //start timer

            ViewBag.Message = "Stack was searched for 'New Entry 1000'. Results are: " + myStack.Contains("New Entry 1000");

            timer.Stop(); //stop timer
            ViewBag.MyData = myStack;
            ViewBag.Stopwatch = "Completed in " + timer.Elapsed + " seconds";

            return View("Index");
        }
    }
}