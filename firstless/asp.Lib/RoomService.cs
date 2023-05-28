using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asp.Lib
{
	public class RoomService
	{
		EntityModel db = new EntityModel();
		public bool AddRoomProperties(RoomProperty roomProperty)
		{
			try
			{
				db.RoomProperty.Add(roomProperty);
				db.SaveChanges();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
