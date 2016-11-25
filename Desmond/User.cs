using System;
using System.Collections.Generic;

namespace Desmond
{
	public class User
	{
		public User()
		{
		}
		public string Name { get; set; }
		public string Description { get; set; }
		public string Password { get; set; }
	}

	public class Location
	{ 
		public double Lat { get; set; }
		public double Lng { get; set; }
	}

	public class UserWorker
	{
		public UserWorker()
		{

		}
		public List<User> GetDemoUsers(IService service)
		{
			return service.GetDemoUsers();
		}
	}
}
