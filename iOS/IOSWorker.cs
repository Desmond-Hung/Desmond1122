using System;
using System.Collections.Generic;

namespace Desmond.iOS
{
	public class IOSWorker:IService
	{
		public IOSWorker()
		{
		}

		public List<Restaurant> GetDemoRestaurants()
		{
			var list = new List<Restaurant>
			{
				new Restaurant {Name = @"武廟市場", Address = @"高雄市苓雅區輔仁路123號", Phone = @"0987998778", Location2D = new Location(){ Lat = 22.629905, Lng = 120.331748}, Image = "res_type_1.png"},
				new Restaurant {Name = @"武廟黑輪", Address = @"高雄市苓雅區輔仁路27號", Phone = @"0933556443", Location2D = new Location(){ Lat = 22.629880, Lng = 120.331748}, Image = "res_type_2.png"},
				new Restaurant {Name = @"善鼎豐素食滷味鹹酥雞", Address = @"高雄市苓雅區武廟路69之1號", Phone = @"07-7239845", Location2D = new Location(){ Lat = 22.630385, Lng = 120.330595}, Image = "res_type_3.png"},
				new Restaurant {Name = @"武廟萬丹紅豆餅", Address = @"高雄市苓雅區武廟路36號", Phone = @"0911445667", Location2D = new Location(){ Lat = 22.630137, Lng = 120.332076}, Image = "res_type_4.png"}
			};
			return list;
		}
	}
}
