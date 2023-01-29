﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace KeySystemBot
{
    internal class Program
    {
		static VMApi API = new VMApi();
		String Version = "0.1";
		

		private List<long> TrustedUsers = new List<long>();

		
		private DiscordSocketClient _client;

		static void Main(string[] args)
        {
			Console.WriteLine(API.List());
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
		public readonly String[] Server = {
				"Windows_2019_eval",
				"CentOS_7",
				"Ubuntu 22.10",
				"valid_os",
				"Debian 11.0"
		};
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
					await message.Channel.SendMessageAsync("Content: ", false, val.Build());
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
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}


				return Task.CompletedTask;
			}
			else if (message.Content.StartsWith("!delVM"))
			{
				String[] Args = message.Content.Split(' ');
				try
				{
					if (API.DeleteServer(Server[Int32.Parse(Args[1])]))
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server Sucesfully Deleted!");
						val.AddField("Vm ID:", Server[Int32.Parse(Args[1])]);
						val.WithColor(Color.Green);
						await message.Channel.SendMessageAsync("", false, val.Build());
					}
					else
					{
						EmbedBuilder val = new EmbedBuilder();
						val.WithTitle("Server Failed to Delete Server!");
						val.AddField("Vm ID:", Server[Int32.Parse(Args[1])]);
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
				
				try
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("Server Sucesfully Getting Server!");
					val.AddField("Vm ID:",API.List());
					val.WithColor(Color.Green);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
				catch (Exception e)
				{
					EmbedBuilder val = new EmbedBuilder();
					val.WithTitle("Server Failed to Getting Server List!");
					val.AddField("Vm ID:", "Null");
					val.WithColor(Color.Red);
					await message.Channel.SendMessageAsync("", false, val.Build());
				}
			}
			else if (message.Content.StartsWith("!delVM"))
			{
				String[] Args = message.Content.Split(' ');
				try
				{

				}
				catch (Exception e)
				{

				}
			}


			if (message.Content == "fevregv")
			{
				EmbedBuilder val7 = new EmbedBuilder();
				val7.WithTitle("Help");
				val7.WithDescription("- ");
				val7.WithColor(Color.Teal);
				await message.Channel.SendMessageAsync("", false, val7.Build(), (RequestOptions)null, (AllowedMentions)null, (MessageReference)null, (MessageComponent)null, (ISticker[])null, (Embed[])null, (MessageFlags)0);
			}
			return Task.CompletedTask;
		}
	}
}
