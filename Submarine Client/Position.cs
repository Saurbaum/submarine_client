namespace Submarine_Client
{
	public class Position
	{
		public long X { get; set; }

		public long Y { get; set; }

		public override string ToString()
		{
			return $"{this.X}, {this.Y}";
		}
	}
}
