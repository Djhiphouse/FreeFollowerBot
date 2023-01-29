using System;
using System.Collections.Generic;
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
		enum Server
		{
			valid_os,
			Windows_2019_eval,
			CentOS_7
		}

		private List<long> TrustedUsers = new List<long>();

		
		private DiscordSocketClient _client;
		DiscordConfig DiscordConfig_config;
		DiscordSocketConfig DiscordSocketConfig_discordSocketConfig = new DiscordSocketConfig();
		static void Main(string[] args)
        {
			
			new Program().MainAsync().GetAwaiter().GetResult();
		}

		public async Task MainAsync()
		{
			var token = "MTA2OTA3NTQwODI2OTYxMTEyOQ.GcQ9i9.b4ImlKBRazCFnj5jfNtM3lTS0LKmD7i21FDhZw";
			_client = new DiscordSocketClient();
			_client.MessageReceived += CommandHandler;
			_client.Log += Log;
			DiscordConfig_config = new DiscordConfig();
			DiscordConfig_config.UseInteractionSnowflakeDate= true;
			DiscordSocketConfig_discordSocketConfig.LogGatewayIntentWarnings= true;
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
				String[] Args = message.Content.Split(' ');
				EmbedBuilder val = new EmbedBuilder();
				val.AddField("Test", 1, true);
				val.WithTitle("Create Server");
				val.WithDescription("Server created Sucessfully ID: " );
				val.WithColor(Color.Red);
				await message.Channel.SendMessageAsync("Content: ", false, val.Build());
				return Task.CompletedTask;
			}

			
			
			if (message.Content == "help")
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
