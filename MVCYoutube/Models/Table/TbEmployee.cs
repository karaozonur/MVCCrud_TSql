using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCYoutube.Models.Table
{
    public class TbEmployee
    {
		public int EmployeeID { get; set; }
		public string Name { get; set; }
		public short Age { get; set; }
		public string State { get; set; }
		public string County { get; set; }

		//public TbCounty _county { get; set } = new TbCounty();
	}
}