using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServicesDemo
{
	/// <summary>
	/// Summary description for CalculatorWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class CalculatorWebService : System.Web.Services.WebService
	{

		[WebMethod(EnableSession = true,Description ="Bu method 2 sayıyı toplar",
			CacheDuration =15)]
		public int Add(int firstNumber, int secondNumber)
		{
			List<string> calculations;
			if (Session["CALCULATIONS"] == null)
			{
				calculations = new List<string>();
			}
			else
			{
				calculations = (List<string>)Session["CALCULATIONS"];
			}

			string strRecentCalculation = firstNumber.ToString() + " + " + secondNumber.ToString() +
				"=" + (firstNumber + secondNumber).ToString();

			calculations.Add(strRecentCalculation);
			Session["CALCULATIONS"] = calculations;
				 
			return firstNumber + secondNumber;
		}

		[WebMethod(EnableSession = true)]
		public List<string> GetCalculations()
		{
			if (Session["CALCULATIONS"] == null)
			{
				List<string> calculations = new List<string>();
				calculations.Add("Herhangi bir hesaplama yapmadınız.");
				return calculations;
			}
			else
			{
				return (List<string>)Session["CALCULATIONS"];
			}
		}

	}
}
