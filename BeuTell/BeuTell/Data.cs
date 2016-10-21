using System;
namespace BeuTell
{
	public class Data
	{

		public string Name { get; private set; }

		public Data(string name)
		{
			Name = name;

		}

		public override string ToString()
		{
			return Name;
		}
	}
}