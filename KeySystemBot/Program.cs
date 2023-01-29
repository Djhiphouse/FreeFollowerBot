using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using static KeySystemBot.VMApi;

namespace KeySystemBot
{
    internal class Program
    {
		static VMApi API = new VMApi();
		String Version = "0.1";
		

		private List<long> TrustedUsers = new List<long>();

		
		private DiscordSocketClient _client;
		public static readonly String[] Server = {
				"Windows_2019_eval",
				"CentOS_7",
				"Ubuntu 22.10",
				"valid_os",
				"Debian 11.0"
		};
		static void Main(string[] args)
        {
			//Console.WriteLine("Reinstall: " + API.ReinstallServer("20037", Server[2]));
			new Program().MainAsync().GetAwaiter().GetResult();
		}

		public async Task MainAsync()
		{

			var token = "MTA2OTA3NTQwODI2OTYxMTEyOQ.GcQ9i9.b4ImlKBRazCFnj5jfNtM3lTS0LKmD7i21FDhZw";
			_client = new DiscordSocketClient();
			_client.MessageReceived += CommandHandler;
			_client.Log += Log;
			
			var config = new DiscordSocketConfig
			{
				GatewayIntents = GatewayIntents.All
			};
			 var client = new DiscordSocketClient(config);
			client.MessageReceived += CommandHandler;
			client.Log += Log;
			await client.LoginAsync(TokenType.Bot, token);
			await client.StartAsync();
			

			await Task.Delay(-1);
		}

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(((LogMessage)(msg)).ToString((StringBuilder)null, true, true, DateTimeKind.Local, (int?)11));
			return Task.CompletedTask;
		}
		
		private async Task<Task> CommandHandler(SocketMessage message)
		{
			//1 2 3
			if (message == null)
				Console.WriteLine("Message is Null");

			Console.WriteLine("+++LINE: " + message.Content);

			if (message.Content.StartsWith("!Create"))
			{
				if (message.Content.Contains("help"))
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("Server Creator Help");
					val.AddField("**Components Options**:", "-----------");
					val.AddField("Cores: ", "2 - 16");
					val.AddField("Ram: ", "265 - 65000");
					val.AddField("Disk: ", "10 - 300 (onlyin 10s Steps)");
					val.WithDescription("Server Options: ");
					val.AddField("**Server Options**:", "-----------");
					val.AddField("Windows Server:", "1");
					val.AddField("Centos 7 Server:", "2");
					val.AddField("Ubuntu Server:", "3");
					val.AddField("valid os Server:", "4");
					val.AddField("Debian Server:", "5");
					val.WithDescription("***Use !Create [Cores] [Ram] [Disk] [Server]***");
					val.WithColor(Color.Blue);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
				String[] Args = message.Content.Split(' ');
				Console.WriteLine(String.Join(",", Args));
				try
				{
					if (API.CreateServer(Server[Int32.Parse(Args[1])], Int32.Parse(Args[1]), Int32.Parse(Args[2]), Int32.Parse(Args[3])))
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[Int32.Parse(Args[1])]);
						val.AddField("Cores:", Args[1]);
						val.AddField("Ram: ", Args[2]);
						val.AddField("Disk: ", Args[3]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
					}
					else
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created failed");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[Int32.Parse(Args[1])]);
						val.AddField("Cores:", Args[1]);
						val.AddField("Ram: ", Args[2]);
						val.AddField("Disk: ", Args[3]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Red);
						await message.Channel.SendMessageAsync("", false, val.Build());
					}
				}
				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("Server created failed");
					val.WithDescription("Informations:");
					val.AddField("Server", Server[Int32.Parse(Args[1])]);
					val.AddField("Cores:", Args[1]);
					val.AddField("Ram: ", Args[2]);
					val.AddField("Disk: ", Args[3]);
					val.AddField("Created By: ", message.Author);
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}


				return Task.CompletedTask;
			}
			else if (message.Content.StartsWith("!deleteserver"))
			{
				String[] Args = message.Content.Split(' ');
				try
				{
					if (API.DeleteServer(Server[Int32.Parse(Args[1])]))
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server Sucesfully Deleted!");
						val.AddField("Vm ID:", Server[Int32.Parse(Args[1])]);
						val.AddField("Deleted By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("", false, val.Build());
					}
					else
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server Failed to Delete Server!");
						val.AddField("Vm ID:", Server[Int32.Parse(Args[1])]);
						val.AddField("Deleted By: ", message.Author);
						val.WithColor(Color.Red);
						await message.Channel.SendMessageAsync("", false, val.Build());
					}
					
				}
				catch(Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("Server Failed to Delete Server!");
					val.AddField("Vm ID:", Server[Int32.Parse(Args[1])]);
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
			}
			else if (message.Content.StartsWith("!Server-List"))
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
				Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(API.List());
				//Console.WriteLine(myDeserializedClass.data.Count);

				foreach (var item in myDeserializedClass.data)
				{
					Hostnames.Add(item.config.hostname);
					RootPass.Add(item.config.root_login);
					Ipv4.Add(item.config.ipv4);
					OS.Add(item.config.os);
					Mem.Add(item.config.mem.ToString());
					Cores.Add(item.config.cores.ToString());
					VmId.Add(item.vmID.ToString());
					Disk.Add(item.config.disk.ToString());
					Date.Add(item.createDate.ToString());
				}
				try
				{
					for(int i = 0; i< Hostnames.Count; i++)
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server Sucesfully Getting Server!");
						val.AddField("Hostname:", Hostnames[i]);
						val.AddField("IpV4:", Ipv4[i]);
						val.AddField("OS:", OS[i]);
						val.AddField("Ram:", Mem[i]);
						val.AddField("Cores:", Cores[i]);
						val.AddField("VmID:", VmId[i]);
						val.AddField("Disk:", Disk[i]);
						val.AddField("Created:", Date[i]);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("", false, val.Build());
					}
					
				}
				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("Server Failed to Getting Server List!");
					val.AddField("Hostname:", "NULL");
					val.AddField("IpV4:", "NULL");
					val.AddField("OS:", "NULL");
					val.AddField("Ram:", "NULL");
					val.AddField("Cores:", "NULL");
					val.AddField("VmID:", "NULL");
					val.AddField("Disk:", "NULL");
					val.AddField("Created:", "NULL");
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
			}else if (message.Content.StartsWith("!getprice"))
			{
				Roott myDeserializedClass = JsonConvert.DeserializeObject<Roott>(API.GetPrices());

				try
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("**Prices**");
					val.AddField("1x Cores:", myDeserializedClass.data.cores.price + " €");
					val.AddField("1GB Ram:",myDeserializedClass.data.mem.price + " €");
					val.AddField("10GBs Storage:", myDeserializedClass.data.storage.price + " €");
					val.AddField("1x IP:",myDeserializedClass.data.ipv4.price + " €");
					val.WithColor(Color.Green);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}

				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("**Prices Failed**");
					val.AddField("1x Cores:", "NULL" + " €");
					val.AddField("1GB Ram:", "NULL" + " €");
					val.AddField("10GBs Storage:", "NULL" + " €");
					val.AddField("1x IP:", "NULL" + " €");
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}

			}
			if (message.Content.StartsWith("!setrdns"))
			{
				if (message.Content.Contains("help"))
				{
					EmbedBuilder val7 = new EmbedBuilder();
					val7.WithTitle("Rdns Help");
					val7.WithDescription("**Use !setrdns [Domain]");

					val7.WithColor(Color.Teal);
					await message.Channel.SendMessageAsync("", false, val7.Build());
				}
				String[] Args = message.Content.Split(' ');
				try
				{

					if (API.Setrdns(Args[1], Args[2]))
					{
						EmbedBuilder val7 = new EmbedBuilder();
						val7.WithTitle("Server Rdns");
						val7.AddField("VmID: ", Args[1]);
						val7.AddField("Domain: ", Server[Int32.Parse(Args[2])]);
						val7.AddField("Setiing rdns By: ", message.Author);
						val7.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("", false, val7.Build());
					}
					else
					{
						EmbedBuilder val7 = new EmbedBuilder();
						val7.WithTitle("Server Rdns Failed");
						val7.AddField("VmID: ", Args[1]);
						val7.AddField("Domain: ", Server[Int32.Parse(Args[2])]);
						val7.AddField("Setiing rdns By: ", message.Author);
						val7.WithColor(Color.Red);
						await message.Channel.SendMessageAsync("", false, val7.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
					}
				}
				catch (Exception e)
				{
					EmbedBuilder val7 = new EmbedBuilder();
					val7.WithTitle("Server Rdns Failed");
					val7.AddField("VmID: ", Args[1]);
					val7.AddField("Domain: ", Server[Int32.Parse(Args[2])]);
					val7.AddField("Setiing rdns By: ", message.Author);
					val7.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val7.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
				}
				return Task.CompletedTask;

			}

			if (message.Content.StartsWith("!setstatus"))
			{
				if (message.Content.Contains("help"))
				{
					EmbedBuilder val7 = new EmbedBuilder();
					val7.WithTitle("Status Help");
					val7.WithDescription("**Use !setstatus [Status]");
					val7.AddField("Start: ", "1");
					val7.WithColor(Color.Teal);
					await message.Channel.SendMessageAsync("", false, val7.Build());
				}
				String[] Args = message.Content.Split(' ');
				try
				{

					if (API.Setrdns(Args[1], Args[2]))
					{
						EmbedBuilder val7 = new EmbedBuilder();
						val7.WithTitle("Server Rdns");
						val7.AddField("VmID: ", Args[1]);
						val7.AddField("Domain: ", Server[Int32.Parse(Args[2])]);
						val7.AddField("Setiing rdns By: ", message.Author);
						val7.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("", false, val7.Build());
					}
					else
					{
						EmbedBuilder val7 = new EmbedBuilder();
						val7.WithTitle("Server Rdns Failed");
						val7.AddField("VmID: ", Args[1]);
						val7.AddField("Domain: ", Server[Int32.Parse(Args[2])]);
						val7.AddField("Setiing rdns By: ", message.Author);
						val7.WithColor(Color.Red);
						await message.Channel.SendMessageAsync("", false, val7.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
					}
				}
				catch (Exception e)
				{
					EmbedBuilder val7 = new EmbedBuilder();
					val7.WithTitle("Server Rdns Failed");
					val7.AddField("VmID: ", Args[1]);
					val7.AddField("Domain: ", Server[Int32.Parse(Args[2])]);
					val7.AddField("Setiing rdns By: ", message.Author);
					val7.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val7.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
				}
				return Task.CompletedTask;

			}


			if (message.Content.StartsWith("!reinstall"))
			{
				String[] Args = message.Content.Split(' ');
				try
				{
					
					if (API.ReinstallServer(Args[1], Server[Int32.Parse(Args[2])]))
					{
						EmbedBuilder val7 = new EmbedBuilder();
						val7.WithTitle("Server Reinstaller");
						val7.AddField("VmID: ", Args[1]);
						val7.AddField("Server: ", Server[Int32.Parse(Args[2])]);
						val7.AddField("Reinstalled By: ", message.Author);
						val7.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("", false, val7.Build());
					}
					else
					{
						EmbedBuilder val7 = new EmbedBuilder();
						val7.WithTitle("Server Reinstaller Failed");
						val7.AddField("VmID: ", Args[1]);
						val7.AddField("Server: ", Server[Int32.Parse(Args[2])]);
						val7.AddField("Reinstalled By: ", message.Author);
						val7.WithColor(Color.Red);
						await message.Channel.SendMessageAsync("", false, val7.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
					}
				}
				catch(Exception e)
				{
					EmbedBuilder val7 = new EmbedBuilder();
					val7.WithTitle("Server Reinstaller Failed");
					val7.AddField("VmID: ", Args[1]);
					val7.AddField("Server: ", Server[Int32.Parse(Args[2])]);
					val7.AddField("Reinstalled By: ", message.Author);
					val7.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val7.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
				}
				
				
			}
			return Task.CompletedTask;
		}
	}
}
