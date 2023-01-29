using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Discord.Net.Rest;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace KeySystemBot
{
	internal class VMApi
	{


		//Ubuntu 22.10
		//Debian 11.0
		//valid_os,
		//Windows_2019_eval,
		//CentOS_7
		private String[] Server = {
				"Windows_2019_eval",
				"CentOS_7",
				"Ubuntu_20.04",
				"valid_os",
				"Debian 11.0"
		};



		RestClient client;
		public String List()
		{
			List<String> Hostnames = new List<String>();
			List<String> RootPass = new List<String>();
			List<String> Ipv4 = new List<String>();
			List<String> OS = new List<String>();
			List<String> Mem = new List<String>();
			List<String> Cores = new List<String>();
			List<String> VmId = new List<String>();
			List<String> Disk = new List<String>();
			List<String> Date = new List<String>();

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/list");
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			IRestResponse response = client.Execute(request);

			//Console.WriteLine("Hostnames: " + String.Join(",", Hostnames));
			//Console.WriteLine("VmID: " + String.Join(",", VmId));
			//Console.WriteLine("Rootpass: " + String.Join(",", RootPass));
			//Console.WriteLine("IP: " + String.Join(",", Ipv4));
			//Console.WriteLine("Os: " + String.Join(",", OS));
			//Console.WriteLine("Mem: " + String.Join(",", Mem));
			//Console.WriteLine("Cores: " + String.Join(",", Cores));
			//Console.WriteLine("Disk: " + String.Join(",", Disk));
			//Console.WriteLine("CreatedDate: " + String.Join(",", Date));
			//Console.WriteLine("HostNames: "+ String.Join(",", Hostnames));
			return response.Content; 
		}
		public class ServerConfig
		{
			public int cores { get; set; }
			public int mem { get; set; }
			public int disk { get; set; }
			public string rdns { get; set; }
			public string os { get; set; }
			public string ipv4 { get; set; }
			public string root_login { get; set; }
			public string hostname { get; set; }
		}

		public class Datum
		{
			public int vmID { get; set; }
			public object externalID { get; set; }
			public DateTime createDate { get; set; }
			public ServerConfig config { get; set; }
			
		}

		public class Root
		{
			public string status { get; set; }
			public List<Datum> data { get; set; }
	
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

		public class Cores
		{
			public int amount { get; set; }
			public double price { get; set; }
		}

		public class Data
		{
			public Cores cores { get; set; }
			public Mem mem { get; set; }
			public Storage storage { get; set; }
			public Ipv4 ipv4 { get; set; }
		}

		public class Ipv4
		{
			public int amount { get; set; }
			public double price { get; set; }
		}

		public class Mem
		{
			public int amount { get; set; }
			public double price { get; set; }
		}

		public class Roott
		{
			public string status { get; set; }
			public Data data { get; set; }
		}

		public class Storage
		{
			public int amount { get; set; }
			public double price { get; set; }
		}

		public bool ConfigureServer(int Cores, int Ram, int Disk)
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


			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/reset-root");
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
		public bool CreateServer(String Server, int Cores, int Ram, int Disk)
		{


			client = new RestClient("https://sandbox.reselling.24fire.de/vm/create");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9");
			client.AddDefaultParameter("cores", "2");
			client.AddDefaultParameter("mem", "3500");
			client.AddDefaultParameter("disk", "20");
			client.AddDefaultParameter("os", Server);
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

		public bool ReinstallServer(String VMID, String Server)
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

		public bool Setrdns(String VMID, String Domain)
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
		public bool SetStatus(String VMID, Enum Status)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/status/" + Status);
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

		public bool DeleteSnapShot(String VMID, String identifier)
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
