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
			var seabedRequest = WebRequest.Create(host + "/seabed");
			var pingRequest = WebRequest.Create(host + "/ping");
			var locationRequest = WebRequest.Create(host + "/location");

			var seaBed = JsonConvert.DeserializeObject<List<Position>>(GetRequestData(seabedRequest));

			foreach (var s in seaBed)
			{
				Console.WriteLine(s);
			}
			Console.WriteLine(string.Empty);

			Console.WriteLine(GetRequestData(pingRequest));
			Console.WriteLine(string.Empty);

			Console.WriteLine(JsonConvert.DeserializeObject<Position>(GetRequestData(locationRequest)));
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
