using System.Collections.Generic;
using Newtonsoft.Json;

namespace Submarine_Client
{
	using System;
	using System.IO;
	using System.Net;
	class Program
	{
		private static readonly string host = "http://localhost";
		static void Main(string[] args)
		{
			var startRequest = WebRequest.Create(host + "/start");
			var pingRequest = WebRequest.Create(host + "/ping");
			var locationRequest = WebRequest.Create(host + "/location");

			var playerId = GetRequestData(startRequest);
			
			Console.WriteLine($"PlayerId = {playerId}");

			pingRequest.Headers.Add($"PlayerId:{playerId}");
			Console.WriteLine(GetRequestData(pingRequest));
			Console.WriteLine(string.Empty);

			locationRequest.Headers.Add($"PlayerId:{playerId}");
			var locationData = GetRequestData(locationRequest);
			Console.WriteLine(JsonConvert.DeserializeObject<Position>(locationData));
			Console.WriteLine(string.Empty);

			int i = 0;
		}

		private static string GetRequestData(WebRequest request)
		{
			var response = request.GetResponse();

			var dataStream = request.GetResponse().GetResponseStream();

			if (dataStream != null)
			{
				var reader = new StreamReader(dataStream);

				var data = reader.ReadToEnd();

				reader.Close();
				response.Close();

				return data;
			}

			return string.Empty;
		}
	}
}
