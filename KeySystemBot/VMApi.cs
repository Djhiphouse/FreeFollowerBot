using System;
using System.Collections.Generic;
using System.Text;
using Discord.Net.Rest;
using RestSharp;


namespace KeySystemBot
{
	internal class VMApi
	{


		//Ubuntu 22.10
		//Debian 11.0
		enum Server
		{
			valid_os,
			Windows_2019_eval,
			CentOS_7
		}


		RestClient client;
		public String List()
		{
			client = new RestClient("https://sandbox.reselling.24fire.de/vm/list");
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			return response.Content;
		}
		public String GetPrices()
		{
			client = new RestClient("https://sandbox.reselling.24fire.de/vm/prices");
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			return response.Content;
		}
		public bool ConfigureServer(int Cores,int Ram,int Disk)
		{


			client = new RestClient("https://sandbox.reselling.24fire.de/vm/price");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			client.AddDefaultParameter("cores", Cores);
			client.AddDefaultParameter("mem", Ram);
			client.AddDefaultParameter("disk", Disk);
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);

			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}
		public bool ResetPasword(String VMID)
		{


			client = new RestClient("https://sandbox.reselling.24fire.de/vm/"+ VMID + "/reset-root");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			//client.AddDefaultHeader("cores", "2");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);

			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}
		public bool CreateServer(Enum Server)
		{


			client = new RestClient("https://sandbox.reselling.24fire.de/vm/create");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			client.AddDefaultParameter("cores", "2");
			client.AddDefaultParameter("mem", "3500");
			client.AddDefaultParameter("disk", "20");
			client.AddDefaultParameter("os", Server.ToString().Replace("_", " "));
			//client.AddDefaultHeader("cores", "2");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);

			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}

		public bool DeleteServer(String VMID)
		{
			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/delete");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			//client.AddDefaultHeader("cores", "2");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);


			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}

		public bool ReinstallServer(String VMID, Enum Server)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/reinstall");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			client.AddDefaultParameter("os", Server.ToString().Replace("_", " "));
			//client.AddDefaultHeader("cores", "2");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);


			if (response.Content.Contains("success"))
				return true;
			else
				return false;


		}

		public bool Setrdns(String VMID,String Domain)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/rdns");
			var request = new RestRequest(Method.POST);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			client.AddDefaultParameter("domain", Domain);
			//client.AddDefaultHeader("cores", "2");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);


			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}

		public String Status(String VMID)
		{
			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/status");
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			return response.Content;
		}
		public enum ServerStatus
		{
			start,
			stop,
			restart
		}
		public bool SetStatus(String VMID,Enum Status)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/status/"+Status);
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			//client.AddDefaultHeader("cores", "2");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);


			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}
		public String GetSnapShots(String VMID)
		{
			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/snapshot");
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			return response.Content;
		}


		public bool CreateSnapshot(String VMID)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/snapshot");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);

			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}

		public bool DeleteSnapShot(String VMID,String identifier)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/snapshot/" + identifier);
			var request = new RestRequest(Method.DELETE);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);

			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}

		public bool RecoverSnapshot(String VMID, String identifier)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/snapshot/" + identifier);
			var request = new RestRequest(Method.POST);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);

			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}
		public String GetSubscrption()
		{
			
			client = new RestClient("https://sandbox.reselling.24fire.de/accounting/unpaid");
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			return response.Content;
		}
		public String Config(String VMID)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/config");
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			return response.Content;

			
		}
	}
}
