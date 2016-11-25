using System;
using System.Collections.Generic;

namespace Desmond
{
	public class Restaurant
	{
		public Restaurant()
		{
		}
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public Location Location2D { get; set; }
		public string Image { get; set; }
	}

	public class Location
	{ 
		public double Lat { get; set; }
		public double Lng { get; set; }
	}

	public class RestaurantWorker
	{
		public RestaurantWorker()
		{

		}
		public List<Restaurant> GetDemoRestaurants(IService service)
		{
			return service.GetDemoRestaurants();
		}
	}
}
