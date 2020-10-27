using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KamaliProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

		#region Recaptcha
		[HttpPost]
		public ActionResult Login(FormCollection form, string username, string password)
		{
			string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
			string secretKey = "6LcuJNwZAAAAAB4w0N9nsONHQDYQ7qqDxjFjXZw-"; // change this
			string gRecaptchaResponse = form["g-recaptcha-response"];

			var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

			// send post data
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
			request.Method = "POST";
			request.ContentLength = postData.Length;
			request.ContentType = "application/x-www-form-urlencoded";

			using (var streamWriter = new StreamWriter(request.GetRequestStream()))
			{
				streamWriter.Write(postData);
			}

			// receive the response now
			string result = string.Empty;
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					result = reader.ReadToEnd();
				}
			}

			// validate the response from Google reCaptcha
			var captChaesponse = JsonConvert.DeserializeObject<Models.RecaptchaResponse>(result);
			if (!captChaesponse.Success)
			{
				ViewBag.Message = "Sorry, please validate the reCAPTCHA";
				return View();
			}

			// go ahead and write code to validate username password against database
			Models.Account user = new Models.Account();

			if (user.Username != username || user.Password != password)
			{
				ViewBag.Message = "Sorry, Usernam/Password is not valid!!!	";
				return View();
			}

			return Redirect("https://www.varzesh3.com/");
		} 
		#endregion
	}
}