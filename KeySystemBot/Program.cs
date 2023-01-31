using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static KeySystemBot.VMApi;

namespace KeySystemBot
{
	internal class Program
	{
		static VMApi API = new VMApi();
		String Version = "0.1";
		public List<ulong> UserPerms = new List<ulong>();

		private List<long> TrustedUsers = new List<long>();


		private DiscordSocketClient _client;
		public static readonly String[] Server = {
				"Windows 2019 eval",
				"CentOS_7",
				"Ubuntu 22.10",
				"valid_os",
				"Debian 11.0"
		};
		static void Main(string[] args)
		{
			SellixKeySystem sellixKey = new SellixKeySystem();
			sellixKey.LoadKeys();
			//Console.WriteLine("API: " + API.ReturnProdukt("7008d9-e59b60b5cb-1b1d82"));
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

			if (message.Content.StartsWith("!delete") && message.Author.Id == 1067545233811849227)
			{
				String[] Args = message.Content.Split(' ');
				try
				{
					Console.WriteLine("Args" + Args[0]);

					UserPerms.Add(ulong.Parse(Args[0]));
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("GxHost Permission");
					val.AddField("Added Permission to UserID::", Args[0]);
					val.AddField("Deleted By: ", message.Author);
					val.WithColor(Color.Green);
					await message.Channel.SendMessageAsync("", false, val.Build());


				}
				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("GxHost Permission Failed!");
					val.WithDescription("**USE:** !addperms [UserID]");
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
			}
			if (message.Content.StartsWith("!pay"))
			{
				SellixKeySystem KeySystem = new SellixKeySystem();
				if (KeySystem.KeyisUsed(message.Content.Replace("!pay ", "")))
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("KeySystem");
					val.AddField("Key Already Used: ", message.Content.Replace("!pay ", ""));
					val.AddField("redeemed By: ", message.Author);
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
					return Task.CompletedTask;
				}
				else
				{
					KeySystem.KeyUsed(message.Content.Replace("!pay ", ""));
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("KeySystem");
					val.AddField("Key Use: ", message.Content.Replace("!pay ", ""));
					val.AddField("redeemed By: ", message.Author);
					val.WithColor(Color.Green);
					await message.Channel.SendMessageAsync("", false, val.Build());
					Console.WriteLine("All Keys: " + String.Join(",", KeySystem.keys));
					return Task.CompletedTask;
				}
				String[] Args = message.Content.Split(' ');
				String ID = API.GetProdukt(message.Content.Replace("!pay ", ""));
				String Product = API.ReturnProdukt(ID);
				//Console.WriteLine("Product: " + Product.Length + " Test: " + String.Join(",", Product));
				Console.WriteLine("Product: " + Product.Length + " Test: " + Product);


				try
				{

					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("Server Manager");
					val.AddField("Invoice ID:", Args[1]);
					val.AddField("redeemed By: ", message.Author);
					val.WithColor(Color.Green);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					Console.WriteLine("Products: " + string.Join(" - ", Product));
				}




				//4
				if (Product == "63d6f67269074")
				{
					if (Product == "63d868029e55b")
					{
						String[] Server = API.CreateServer("Debian 11.0", 4, 12000, 80).Split(":");


						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());


						return Task.CompletedTask;
					}
					else
					{
						String[] Server = API.CreateServer("Windows 2019 eval", 4, 12000, 80).Split(":");

						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());


					}
					//5
				}
				else if (Product == "63d6f68eb7561")
				{
					if (Product == "63d8688ad89f2")
					{
						String[] Server = API.CreateServer("Debian 11.0", 4, 12000, 90).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
						return Task.CompletedTask;
					}
					else
					{
						String[] Server = API.CreateServer("Windows 2019 eval", 4, 12000, 90).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
					}
				}
				//6
				else if (Product == "63d6f69a4fa70")
				{
					if (Product == "63d868e0dbf23")
					{
						String[] Server = API.CreateServer("Debian 11.0", 10, 16000, 70).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
						return Task.CompletedTask;
					}
					else
					{
						API.CreateServer("Windows 2019 eval", 10, 16000, 70).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
					}
				}
				//7
				else if (Product == "63d6f6aac0d33")
				{
					if (Product == "63d8693836a7e")
					{
						String[] Server = API.CreateServer("Debian 11.0", 6, 24000, 100).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
						return Task.CompletedTask;
					}
					else
					{
						String[] Server = API.CreateServer("Windows 2019 eval", 6, 24000, 100).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
					}
				}
				//8
				else if (Product == "63d6f6c2dd7d9")
				{
					if (Product == "63d869b529a62")
					{
						String[] Server = API.CreateServer("Debian 11.0", 8, 32000, 150).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
						return Task.CompletedTask;
					}
					else
					{
						API.CreateServer("Windows 2019 eval", 8, 32000, 150).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
					}
				}
				//9
				else if (Product == "63d6f6db910cd")
				{
					if (Product == "63d86a00a9c14")
					{
						String[] Server = API.CreateServer("Debian 11.0", 11, 56000, 210).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
						return Task.CompletedTask;
					}
					else
					{
						API.CreateServer("Windows 2019 eval", 11, 56000, 210).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
					}
				}
				//10
				else if (Product == "63d6f70567a65")
				{
					if (Product == "63d86a717243b")
					{
						String[] Server = API.CreateServer("Debian 11.0", 12, 64000, 200).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
						return Task.CompletedTask;
					}
					else
					{
						String[] Server = API.CreateServer("Windows 2019 eval", 12, 64000, 200).Split(":");
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server created Sucessfully");
						val.WithDescription("Informations:");
						val.AddField("Server", Server[1]);
						val.AddField("VmID", Server[0]);
						val.AddField("Root Password:", Server[2]);
						val.AddField("Ipv4:", Server[3]);
						val.AddField("Cores:", Server[4]);
						val.AddField("Ram: ", Server[5]);
						val.AddField("Disk: ", Server[6]);
						val.AddField("Status:", Server[7]);
						val.AddField("Created By: ", message.Author);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("Content: ", false, val.Build());
					}
				}

			}

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
					API.CreateServer(Server[Int32.Parse(Args[1])], Int32.Parse(Args[1]), Int32.Parse(Args[2]), Int32.Parse(Args[3]));

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


					EmbedBuilder vall = new EmbedBuilder();
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
			else if (message.Content.StartsWith("!delete") && message.Author.Id == 1067545233811849227 || UserPerms.Contains(message.Author.Id))
			{
				String[] Args = message.Content.Split(' ');
				try
				{
					Console.WriteLine("Args" + Args[0]);
					if (API.DeleteServer(Server[Int32.Parse(String.Join("", Args).Replace("!delete", ""))]))
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server Sucesfully Deleted!");
						val.AddField("Vm ID:", String.Join("", Args).Replace("!delete", ""));
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
				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("Server Failed to Delete Server!");
					val.AddField("Vm ID:", Server[Int32.Parse(Args[1])]);
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
			}
			else if (message.Content.StartsWith("!Server-List") && message.Author.Id == 1067545233811849227 || UserPerms.Contains(message.Author.Id))
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
					for (int i = 0; i < Hostnames.Count; i++)
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
			}
			else if (message.Content.StartsWith("!getprice"))
			{


				EmbedBuilder val = new EmbedBuilder();
				val.WithTitle("**Prices**");
				val.AddField("1x Cores:", "0.90 €");
				val.AddField("1GB Ram:", "0.70 €");
				val.AddField("10GBs Storage:", "0.70 €");
				val.WithColor(Color.Green);
				await message.Channel.SendMessageAsync("", false, val.Build());


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
			if (message.Content.StartsWith("!status"))
			{
				String[] Args = message.Content.Split(' ');
				try
				{

					String Data = API.Status(Args[1]);
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("**Server Status**");
					val.AddField("Status:", Data.Split(":")[0]);
					val.AddField("CPU Usage:", Data.Split(":")[1]);
					val.AddField("RAM Usage:", Data.Split(":")[2]);
					val.AddField("UPTIME:", Data.Split(":")[3]);
					val.WithColor(Color.Green);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("**Server Status Failed**");
					val.AddField("VmID: ", Args[1]);
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}


			}

			if (message.Content.StartsWith("!configureServer") && message.Author.Id == 1067545233811849227 || UserPerms.Contains(message.Author.Id))
			{
				String[] Args = message.Content.Split(' ');
				try
				{

					if (API.ConfigureServer(Int32.Parse(Args[1]), Int32.Parse(Args[2]), Int32.Parse(Args[3]), Int32.Parse(Args[4])))
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("**Server Configured**");
						val.AddField("VmID:", Args[1]);
						val.AddField("Cores:", Args[2]);
						val.AddField("RAM:", Args[3]);
						val.AddField("Disk:", Args[4]);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("", false, val.Build());
					}
					else
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("**Server Configured Failed**");
						val.AddField("VmID:", Args[1]);
						val.WithColor(Color.Red);
						await message.Channel.SendMessageAsync("", false, val.Build());
					}

				}
				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("**Server Configured Failed**");
					val.AddField("VmID:", Args[1]);
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}


			}

			if (message.Content.StartsWith("!resetpassword"))
			{
				String[] Args = message.Content.Split(' ');
				String Password = API.ResetPasword(Args[1]);
				try
				{

					String Data = API.Status(Args[1]);
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("**Server Password Change**");
					val.AddField("New Password:", Password);
					val.WithColor(Color.Green);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("**Server Password Change**");
					val.AddField("Password: ", Password);
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}


			}


			if (message.Content.StartsWith("!config"))
			{
				String[] Args = message.Content.Split(' ');
				String Data = API.Config(Args[1]);
				try
				{


					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("**Server Cofig**");
					val.AddField("Hostname:", Data.Split(":")[0]);
					val.AddField("Ipv4:", Data.Split(":")[1]);
					val.AddField("Login Name:", Data.Split(":")[2]);
					val.AddField("Root Password:", Data.Split(":")[3]);
					val.AddField("Cores:", Data.Split(":")[4]);
					val.AddField("Disk:", Data.Split(":")[5]);
					val.AddField("Ram:", Data.Split(":")[6]);
					val.AddField("OS:", Data.Split(":")[7]);
					val.AddField("Create Date:", Data.Split(":")[8] + "\n\n");
					val.AddField("**Prices:**", "-----------");
					val.AddField("Price Per Hour:", Data.Split(":")[9] + " €");
					val.AddField("Price Per Day:", Data.Split(":")[10] + " €");
					val.AddField("Price Per Month:", Data.Split(":")[11] + " €");
					val.WithColor(Color.Green);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("**Server Cofig Failed**");
					val.AddField("VmID: ", Args[1]);
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}


			}

			if (message.Content.StartsWith("!setstatus"))
			{
				String CurrentStatus = "restart";
				if (message.Content.Contains("help"))
				{
					EmbedBuilder val7 = new EmbedBuilder();
					val7.WithTitle("Status Help");
					val7.WithDescription("**Use !setstatus [Status]");
					val7.AddField("Start: ", "1");
					val7.AddField("Restart: ", "2");
					val7.AddField("Stop: ", "3");
					val7.WithColor(Color.Teal);
					await message.Channel.SendMessageAsync("", false, val7.Build());
				}
				String[] Args = message.Content.Split(' ');
				try
				{

					switch (Args[2])
					{
						case "1":
							CurrentStatus = "start";
							break;

						case "2":
							CurrentStatus = "stop";
							break;

						case "3":
							CurrentStatus = "restart";
							break;
					}
					if (API.SetStatus(Args[1], CurrentStatus))
					{
						EmbedBuilder val7 = new EmbedBuilder();
						val7.WithTitle("Server Status");
						val7.WithDescription("Status set to " + "**" + CurrentStatus + "**");
						val7.AddField("Status set By: ", message.Author);
						val7.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("", false, val7.Build());
					}
					else
					{
						EmbedBuilder val7 = new EmbedBuilder();
						val7.WithTitle("Server Status Failed");
						val7.WithDescription("Status set to " + "**" + CurrentStatus + "**");
						val7.AddField("Status set By: ", message.Author);
						val7.WithColor(Color.Red);
						await message.Channel.SendMessageAsync("", false, val7.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
					}
				}
				catch (Exception e)
				{
					EmbedBuilder val7 = new EmbedBuilder();
					val7.WithTitle("Server Status Failed");
					val7.WithDescription("Status set to " + "**" + CurrentStatus + "**");
					val7.AddField("Status set By: ", message.Author);
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
				catch (Exception e)
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
