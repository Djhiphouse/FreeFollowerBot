using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace KeySystemBot
{

	public class SellixKeySystem
	{
		public List<string> keys = new List<string>();
		StreamWriter streamWriter;


		public void LoadKeys()
		{
			StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\UsedKey.keys");


			String line = "";
			while (line != null)
			{
				line = streamReader.ReadLine();
				keys.Add(line);
			}


			streamReader.Close();
			Console.WriteLine("All Keys: " + String.Join(",", keys));

		}
		public void KeyUsed(String Key)
		{
			if (!File.Exists(Directory.GetCurrentDirectory() + "\\UsedKey.keys"))
			{
				File.Create(Directory.GetCurrentDirectory() + "\\UsedKey.keys");
			}
			else
			{
				Console.WriteLine("Write in Config");
				streamWriter = new StreamWriter((Directory.GetCurrentDirectory() + "\\UsedKey.keys"));
				streamWriter.AutoFlush = true;
				streamWriter.WriteLine(Key);
				streamWriter.Flush();
				streamWriter.Close();
				keys.Add(Key);

			}

		}
		public bool KeyisUsed(String Key)
		{
			try
			{

				for (int i = 0; i <= keys.Count; i++)
				{
					if (keys[i].Contains(Key))
						return true;

				}


			}
			catch (Exception e)
			{
				Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + e.Message + "++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
				return false;
			}
			return false;

		}
	}
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
		String SellixKey = "HGtMZdYGrkLBDRByh91WY5HqDj5X4tgnHVAYidRzDWhWq7XL48iaTFNNLj3xEr8h";
		String HostResellKey = "1tWXW6lIy7LPKYLJM2HERp4805C3rGZ9";


		RestClient client;
		public class SellixStuff
		{
			// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
			public class CustomField
			{
				public string type { get; set; }
				public string name { get; set; }
			}

			public class Data
			{
				public Product product { get; set; }
			}

			public class Feedback
			{
				public int total { get; set; }
				public int positive { get; set; }
				public int neutral { get; set; }
				public int negative { get; set; }
				public List<object> numbers { get; set; }
				public List<object> list { get; set; }
			}

			public class Log
			{
				[JsonProperty("1.start")]
				public long _1start { get; set; }

				[JsonProperty("2.shop")]
				public int _2shop { get; set; }

				[JsonProperty("3.errors")]
				public int _3errors { get; set; }

				[JsonProperty("4.infocard")]
				public int _4infocard { get; set; }

				[JsonProperty("6.averagescore")]
				public int _6averagescore { get; set; }

				[JsonProperty("7.sold_count")]
				public int _7sold_count { get; set; }

				[JsonProperty("8.regex")]
				public int _8regex { get; set; }

				[JsonProperty("9.view")]
				public int _9view { get; set; }
			}

			public class PriceConversions
			{
				public int CAD { get; set; }
				public int HKD { get; set; }
				public int ISK { get; set; }
				public int PHP { get; set; }
				public int DKK { get; set; }
				public int HUF { get; set; }
				public int CZK { get; set; }
				public int GBP { get; set; }
				public int RON { get; set; }
				public int SEK { get; set; }
				public int IDR { get; set; }
				public int INR { get; set; }
				public int BRL { get; set; }
				public int RUB { get; set; }
				public int HRK { get; set; }
				public int JPY { get; set; }
				public int THB { get; set; }
				public int CHF { get; set; }
				public int EUR { get; set; }
				public int MYR { get; set; }
				public int BGN { get; set; }
				public int TRY { get; set; }
				public int CNY { get; set; }
				public int NOK { get; set; }
				public int NZD { get; set; }
				public int ZAR { get; set; }
				public int USD { get; set; }
				public int MXN { get; set; }
				public int SGD { get; set; }
				public int AUD { get; set; }
				public int ILS { get; set; }
				public int KRW { get; set; }
				public int PLN { get; set; }
			}

			public class Product
			{
				public int id { get; set; }
				public string uniqid { get; set; }
				public string slug { get; set; }
				public int shop_id { get; set; }
				public string type { get; set; }
				public object subtype { get; set; }
				public string title { get; set; }
				public string currency { get; set; }
				public int pay_what_you_want { get; set; }
				public int price { get; set; }
				public int price_display { get; set; }
				public int price_discount { get; set; }
				public int affiliate_revenue_percent { get; set; }
				public object price_variants { get; set; }
				public string description { get; set; }
				public string image_attachment { get; set; }
				public string file_attachment { get; set; }
				public object youtube_link { get; set; }
				public List<object> volume_discounts { get; set; }
				public object recurring_interval { get; set; }
				public object recurring_interval_count { get; set; }
				public object trial_period { get; set; }
				public object paypal_product_id { get; set; }
				public object paypal_plan_id { get; set; }
				public object stripe_price_id { get; set; }
				public int discord_integration { get; set; }
				public int discord_optional { get; set; }
				public int discord_set_role { get; set; }
				public object discord_server_id { get; set; }
				public object discord_role_id { get; set; }
				public int discord_remove_role { get; set; }
				public int quantity_min { get; set; }
				public int quantity_max { get; set; }
				public int quantity_warning { get; set; }
				public List<string> gateways { get; set; }
				public List<CustomField> custom_fields { get; set; }
				public int crypto_confirmations_needed { get; set; }
				public int max_risk_level { get; set; }
				public bool block_vpn_proxies { get; set; }
				public string delivery_text { get; set; }
				public int delivery_time { get; set; }
				public string service_text { get; set; }
				public string stock_delimiter { get; set; }
				public int stock { get; set; }
				public string dynamic_webhook { get; set; }
				public int sort_priority { get; set; }
				public bool unlisted { get; set; }
				public int on_hold { get; set; }
				public string terms_of_service { get; set; }
				public int warranty { get; set; }
				public string warranty_text { get; set; }
				public int watermark_enabled { get; set; }
				public string watermark_text { get; set; }
				public object redirect_link { get; set; }
				public bool @private { get; set; }
				public int created_at { get; set; }
				public int updated_at { get; set; }
				public int updated_by { get; set; }
				public int marketplace_category_id { get; set; }
				public string name { get; set; }
				public object image_name { get; set; }
				public object image_storage { get; set; }
				public object cloudflare_image_id { get; set; }
				public Feedback feedback { get; set; }
				public List<object> categories { get; set; }
				public List<object> payment_gateways_fees { get; set; }
				public List<object> serials { get; set; }
				public List<object> webhooks { get; set; }
				public PriceConversions price_conversions { get; set; }
				public string theme { get; set; }
				public int dark_mode { get; set; }
				public string vat_percentage { get; set; }
				public TaxDetails tax_details { get; set; }
				public object average_score { get; set; }
				public int sold_count { get; set; }
				public List<object> addons { get; set; }
			}

			public class Root
			{
				public int status { get; set; }
				public Data data { get; set; }
				public object error { get; set; }
				public object message { get; set; }
				public string env { get; set; }
				public Log log { get; set; }
			}

			public class TaxDetails
			{
				public string vat_percentage { get; set; }
				public string tax_configuration { get; set; }
				public List<object> tax_configuration_data { get; set; }
				public int display_tax_on_storefront { get; set; }
				public int display_tax_custom_fields { get; set; }
				public int validation_only_for_companies { get; set; }
				public int validate_vat_number { get; set; }
				public int prices_tax_inclusive { get; set; }
			}


		}

		public class AllOrders
		{
			public class Data
			{
				public Order order { get; set; }
			}

			public class Feedback
			{
				public int total { get; set; }
				public int positive { get; set; }
				public int neutral { get; set; }
				public int negative { get; set; }
				public List<object> numbers { get; set; }
				public List<object> list { get; set; }
			}

			public class IpInfo
			{
				public bool success { get; set; }
				public string message { get; set; }
				public int fraud_score { get; set; }
				public string country_code { get; set; }
				public string region { get; set; }
				public string city { get; set; }
				public string ISP { get; set; }
				public int ASN { get; set; }
				public string operating_system { get; set; }
				public string browser { get; set; }
				public string organization { get; set; }
				public bool is_crawler { get; set; }
				public string timezone { get; set; }
				public bool mobile { get; set; }
				public string host { get; set; }
				public bool proxy { get; set; }
				public bool vpn { get; set; }
				public bool tor { get; set; }
				public bool active_vpn { get; set; }
				public bool active_tor { get; set; }
				public string device_brand { get; set; }
				public string device_model { get; set; }
				public bool recent_abuse { get; set; }
				public bool bot_status { get; set; }
				public string connection_type { get; set; }
				public string abuse_velocity { get; set; }
				public string zip_code { get; set; }
				public double latitude { get; set; }
				public double longitude { get; set; }
				public string request_id { get; set; }
				public object transaction_details { get; set; }
				public int asn { get; set; }
				public string isp { get; set; }
			}

			public class Log
			{
				[JsonProperty("1.start")]
				public long _1start { get; set; }

				[JsonProperty("2.shop")]
				public int _2shop { get; set; }

				[JsonProperty("3.errors")]
				public int _3errors { get; set; }

				[JsonProperty("4.infocard")]
				public int _4infocard { get; set; }

				[JsonProperty("6.averagescore")]
				public int _6averagescore { get; set; }

				[JsonProperty("7.sold_count")]
				public int _7sold_count { get; set; }

				[JsonProperty("8.regex")]
				public int _8regex { get; set; }

				[JsonProperty("9.view")]
				public int _9view { get; set; }
			}

			public class Order
			{
				public int id { get; set; }
				public string uniqid { get; set; }
				public object recurring_billing_id { get; set; }
				public string type { get; set; }
				public object subtype { get; set; }
				public int total { get; set; }
				public int total_display { get; set; }
				public object product_variants { get; set; }
				public double exchange_rate { get; set; }
				public int crypto_exchange_rate { get; set; }
				public string currency { get; set; }
				public int shop_id { get; set; }
				public string shop_image_name { get; set; }
				public string shop_image_storage { get; set; }
				public string cloudflare_image_id { get; set; }
				public string name { get; set; }
				public string customer_email { get; set; }
				public object affiliate_revenue_customer_id { get; set; }
				public bool paypal_email_delivery { get; set; }
				public string product_id { get; set; }
				public string product_title { get; set; }
				public string product_type { get; set; }
				public object subscription_id { get; set; }
				public object subscription_time { get; set; }
				public string gateway { get; set; }
				public object blockchain { get; set; }
				public object paypal_apm { get; set; }
				public object stripe_apm { get; set; }
				public object paypal_email { get; set; }
				public object paypal_order_id { get; set; }
				public object paypal_payer_email { get; set; }
				public int paypal_fee { get; set; }
				public object paypal_subscription_id { get; set; }
				public object paypal_subscription_link { get; set; }
				public object lex_order_id { get; set; }
				public object lex_payment_method { get; set; }
				public object paydash_paymentID { get; set; }
				public object virtual_payments_id { get; set; }
				public object stripe_client_secret { get; set; }
				public object stripe_price_id { get; set; }
				public object skrill_email { get; set; }
				public object skrill_sid { get; set; }
				public object skrill_link { get; set; }
				public object perfectmoney_id { get; set; }
				public object binance_invoice_id { get; set; }
				public object binance_qrcode { get; set; }
				public object binance_checkout_url { get; set; }
				public object crypto_address { get; set; }
				public int crypto_amount { get; set; }
				public int crypto_received { get; set; }
				public object crypto_uri { get; set; }
				public int crypto_confirmations_needed { get; set; }
				public bool crypto_scheduled_payout { get; set; }
				public int crypto_payout { get; set; }
				public bool fee_billed { get; set; }
				public object bill_info { get; set; }
				public object cashapp_qrcode { get; set; }
				public object cashapp_note { get; set; }
				public object cashapp_cashtag { get; set; }
				public string country { get; set; }
				public string location { get; set; }
				public string ip { get; set; }
				public bool is_vpn_or_proxy { get; set; }
				public string user_agent { get; set; }
				public int quantity { get; set; }
				public object coupon_id { get; set; }
				public object custom_fields { get; set; }
				public bool developer_invoice { get; set; }
				public object developer_title { get; set; }
				public object developer_webhook { get; set; }
				public object developer_return_url { get; set; }
				public string status { get; set; }
				public object status_details { get; set; }
				public object void_details { get; set; }
				public int discount { get; set; }
				public int fee_percentage { get; set; }
				public object fee_breakdown { get; set; }
				public int day_value { get; set; }
				public string day { get; set; }
				public string month { get; set; }
				public int year { get; set; }
				public object product_addons { get; set; }
				public int created_at { get; set; }
				public int updated_at { get; set; }
				public int updated_by { get; set; }
				public IpInfo ip_info { get; set; }
				public string service_text { get; set; }
				public List<object> webhooks { get; set; }
				public object paypal_dispute { get; set; }
				public List<object> product_downloads { get; set; }
				public List<StatusHistory> status_history { get; set; }
				public List<object> crypto_transactions { get; set; }
				public List<object> products { get; set; }
				public List<string> gateways_available { get; set; }
				public bool shop_paypal_credit_card { get; set; }
				public bool shop_force_paypal_email_delivery { get; set; }
				public Product product { get; set; }
			}

			public class PriceConversions
			{
				public int CAD { get; set; }
				public int HKD { get; set; }
				public int ISK { get; set; }
				public int PHP { get; set; }
				public int DKK { get; set; }
				public int HUF { get; set; }
				public int CZK { get; set; }
				public int GBP { get; set; }
				public int RON { get; set; }
				public int SEK { get; set; }
				public int IDR { get; set; }
				public int INR { get; set; }
				public int BRL { get; set; }
				public int RUB { get; set; }
				public int HRK { get; set; }
				public int JPY { get; set; }
				public int THB { get; set; }
				public int CHF { get; set; }
				public int EUR { get; set; }
				public int MYR { get; set; }
				public int BGN { get; set; }
				public int TRY { get; set; }
				public int CNY { get; set; }
				public int NOK { get; set; }
				public int NZD { get; set; }
				public int ZAR { get; set; }
				public int USD { get; set; }
				public int MXN { get; set; }
				public int SGD { get; set; }
				public int AUD { get; set; }
				public int ILS { get; set; }
				public int KRW { get; set; }
				public int PLN { get; set; }
			}

			public class Product
			{
				public int id { get; set; }
				public string uniqid { get; set; }
				public string slug { get; set; }
				public int shop_id { get; set; }
				public string type { get; set; }
				public object subtype { get; set; }
				public string title { get; set; }
				public string currency { get; set; }
				public int pay_what_you_want { get; set; }
				public int price { get; set; }
				public int price_display { get; set; }
				public int price_discount { get; set; }
				public int affiliate_revenue_percent { get; set; }
				public object price_variants { get; set; }
				public string description { get; set; }
				public string image_attachment { get; set; }
				public string file_attachment { get; set; }
				public object youtube_link { get; set; }
				public List<object> volume_discounts { get; set; }
				public object recurring_interval { get; set; }
				public object recurring_interval_count { get; set; }
				public object trial_period { get; set; }
				public object paypal_product_id { get; set; }
				public object paypal_plan_id { get; set; }
				public object stripe_price_id { get; set; }
				public int discord_integration { get; set; }
				public int discord_optional { get; set; }
				public int discord_set_role { get; set; }
				public object discord_server_id { get; set; }
				public object discord_role_id { get; set; }
				public int discord_remove_role { get; set; }
				public int quantity_min { get; set; }
				public int quantity_max { get; set; }
				public int quantity_warning { get; set; }
				public List<string> gateways { get; set; }
				public object custom_fields { get; set; }
				public int crypto_confirmations_needed { get; set; }
				public int max_risk_level { get; set; }
				public bool block_vpn_proxies { get; set; }
				public string delivery_text { get; set; }
				public int delivery_time { get; set; }
				public string service_text { get; set; }
				public string stock_delimiter { get; set; }
				public int stock { get; set; }
				public string dynamic_webhook { get; set; }
				public int sort_priority { get; set; }
				public bool unlisted { get; set; }
				public int on_hold { get; set; }
				public string terms_of_service { get; set; }
				public int warranty { get; set; }
				public string warranty_text { get; set; }
				public int watermark_enabled { get; set; }
				public string watermark_text { get; set; }
				public object redirect_link { get; set; }
				public bool @private { get; set; }
				public int created_at { get; set; }
				public int updated_at { get; set; }
				public int updated_by { get; set; }
				public int marketplace_category_id { get; set; }
				public string name { get; set; }
				public object image_name { get; set; }
				public object image_storage { get; set; }
				public object cloudflare_image_id { get; set; }
				public Feedback feedback { get; set; }
				public List<object> categories { get; set; }
				public List<object> payment_gateways_fees { get; set; }
				public List<object> serials { get; set; }
				public List<object> webhooks { get; set; }
				public PriceConversions price_conversions { get; set; }
				public string theme { get; set; }
				public int dark_mode { get; set; }
				public string vat_percentage { get; set; }
				public TaxDetails tax_details { get; set; }
				public object average_score { get; set; }
				public int sold_count { get; set; }
				public List<object> addons { get; set; }
			}

			public class Root
			{
				public int status { get; set; }
				public Data data { get; set; }
				public object error { get; set; }
				public object message { get; set; }
				public string env { get; set; }
				public Log log { get; set; }
			}

			public class StatusHistory
			{
				public int id { get; set; }
				public string invoice_id { get; set; }
				public string status { get; set; }
				public string details { get; set; }
				public int created_at { get; set; }
			}

			public class TaxDetails
			{
				public string vat_percentage { get; set; }
				public string tax_configuration { get; set; }
				public List<object> tax_configuration_data { get; set; }
				public int display_tax_on_storefront { get; set; }
				public int display_tax_custom_fields { get; set; }
				public int validation_only_for_companies { get; set; }
				public int validate_vat_number { get; set; }
				public int prices_tax_inclusive { get; set; }
			}
		}
		public String GetProdukt(String ID)
		{


			client = new RestClient("https://dev.sellix.io/v1/orders/" + ID);
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", "Bearer " + SellixKey);
			client.AddDefaultHeader("X-Sellix-Merchant", "GxHost");
			//client.AddDefaultHeader("X-Sellix-Merchant", "MuYo");
			IRestResponse response = client.Execute(request);

			AllOrders.Root Orders = JsonConvert.DeserializeObject<AllOrders.Root>(response.Content);



			return Orders.data.order.product_id;
		}
		public String ReturnProdukt(String ID)
		{


			client = new RestClient("https://dev.sellix.io/v1/products/" + ID);
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", "Bearer " + SellixKey);
			client.AddDefaultHeader("X-Sellix-Merchant", "GxHost");
			//client.AddDefaultHeader("X-Sellix-Merchant", "MuYo");
			IRestResponse response = client.Execute(request);

			Console.WriteLine("API: " + response.Content);
			SellixStuff.Root product = JsonConvert.DeserializeObject<SellixStuff.Root>(response.Content);


			return product.data.product.uniqid;



		}


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
			client.AddDefaultHeader("Authorization", HostResellKey);
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
			client.AddDefaultHeader("Authorization", HostResellKey);
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

		public bool ConfigureServer(int id, int Cores, int Ram, int Disk)
		{


			client = new RestClient("https://sandbox.reselling.24fire.de/vm/2" + id + "/change");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", HostResellKey);
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
		public class ServerPassword
		{
			public class Data
			{
				public string password { get; set; }
			}

			public class Root
			{
				public string status { get; set; }
				public Data data { get; set; }
			}

		}
		public String ResetPasword(String VMID)
		{


			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/reset-root");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", HostResellKey);
			//client.AddDefaultHeader("cores", "2");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			ServerPassword.Root myDeserializedClass = JsonConvert.DeserializeObject<ServerPassword.Root>(response.Content);

			if (response.Content.Contains("success"))
				return myDeserializedClass.data.password;
			else
			{
				return "Failed";
			}
		}
		public String CreateServer(String Server, int Cores, int Ram, int Disk)
		{


			client = new RestClient("https://sandbox.reselling.24fire.de/vm/create");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", HostResellKey);
			client.AddDefaultParameter("cores", Cores);
			client.AddDefaultParameter("mem", Ram);
			client.AddDefaultParameter("disk", Disk);
			client.AddDefaultParameter("os", Server);
			//client.AddDefaultHeader("cores", "2");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			CreateServerData.Root myDeserializedClass = JsonConvert.DeserializeObject<CreateServerData.Root>(response.Content);

			if (response.Content.Contains("success"))
			{
				return myDeserializedClass.data.vmid + ":" + myDeserializedClass.data.os + ":" + myDeserializedClass.data.root_password + ":" + myDeserializedClass.data.ipv4 + ":" + myDeserializedClass.data.cores + ":" + myDeserializedClass.data.mem + ":" + myDeserializedClass.data.disk + ":" + myDeserializedClass.data.status;
			}
			else
			{
				return "FAILED" + ":" + "FAILED" + ":" + "FAILED" + ":" + "FAILED" + ":" + "FAILED" + ":" + "FAILED" + ":" + "FAILED" + ":" + "FAILED";
			}

		}
		public class CreateServerData
		{
			public class Data
			{
				public int vmid { get; set; }
				public string os { get; set; }
				public string root_password { get; set; }
				public string ipv4 { get; set; }
				public int cores { get; set; }
				public int mem { get; set; }
				public int disk { get; set; }
				public string status { get; set; }
			}

			public class Root
			{
				public string status { get; set; }
				public Data data { get; set; }
			}

		}
		public bool DeleteServer(String VMID)
		{
			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/delete");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", HostResellKey);
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
			client.AddDefaultHeader("Authorization", HostResellKey);
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
			client.AddDefaultHeader("Authorization", HostResellKey);
			client.AddDefaultParameter("domain", Domain);
			//client.AddDefaultHeader("cores", "2");
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);


			if (response.Content.Contains("success"))
				return true;
			else
				return false;
		}

		public class ServerStatus
		{
			public class Data
			{
				public string status { get; set; }
				public double cpuUsage { get; set; }
				public int usedMem { get; set; }
				public int maxMem { get; set; }
				public int uptime { get; set; }
			}

			public class Root
			{
				public string status { get; set; }
				public Data data { get; set; }
			}


		}
		public String Status(String VMID)
		{
			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/status");
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", HostResellKey);
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			ServerStatus.Root myDeserializedClass = JsonConvert.DeserializeObject<ServerStatus.Root>(response.Content);
			return myDeserializedClass.data.status + ":" + myDeserializedClass.data.cpuUsage + ":" + myDeserializedClass.data.usedMem + ":" + myDeserializedClass.data.uptime;
		}

		public bool SetStatus(String VMID, String Status)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/status/" + Status);
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", HostResellKey);
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
			client.AddDefaultHeader("Authorization", HostResellKey);
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			return response.Content;
		}


		public bool CreateSnapshot(String VMID)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/snapshot");
			var request = new RestRequest(Method.PUT);
			client.AddDefaultHeader("Authorization", HostResellKey);
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
			client.AddDefaultHeader("Authorization", HostResellKey);
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
			client.AddDefaultHeader("Authorization", HostResellKey);
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
			client.AddDefaultHeader("Authorization", HostResellKey);
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			return response.Content;
		}
		public class ServerConfigData
		{
			public class Data
			{
				public int cores { get; set; }
				public int mem { get; set; }
				public int disk { get; set; }
				public string rdns { get; set; }
				public string os { get; set; }
				public string ipv4 { get; set; }
				public string root_login { get; set; }
				public string hostname { get; set; }
				public string login_username { get; set; }
				public DateTime createDate { get; set; }
				public string status { get; set; }
				public Price price { get; set; }
			}

			public class Price
			{
				public double pricePerMonth { get; set; }
				public double pricePerDay { get; set; }
				public double pricePerHour { get; set; }
			}

			public class Root
			{
				public string status { get; set; }
				public Data data { get; set; }
			}


		}
		public String Config(String VMID)
		{

			client = new RestClient("https://sandbox.reselling.24fire.de/vm/" + VMID + "/config");
			var request = new RestRequest(Method.GET);
			client.AddDefaultHeader("Authorization", HostResellKey);
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);
			ServerConfigData.Root Config = JsonConvert.DeserializeObject<ServerConfigData.Root>(response.Content);
			return Config.data.hostname + ":" + Config.data.ipv4 + ":" + Config.data.login_username + ":" + Config.data.root_login + ":" + Config.data.cores + ":" + Config.data.disk + ":" + Config.data.mem + ":" + Config.data.os + ":" + Config.data.createDate + ":" + Config.data.price.pricePerHour + ":" + Config.data.price.pricePerDay + ":" + Config.data.price.pricePerMonth;


		}
	}



}
