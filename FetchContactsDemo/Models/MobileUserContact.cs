using System;
namespace FetchContactsDemo
{
	public class MobileUserContact : BaseModel
	{
		public string Contact_FirstName { get; set; }
		public string Contact_LastName { get; set; }
		public string Contact_DisplayName { get; set; }
		public string Contact_EmailId { get; set; }
		public string Contact_Picture { get; set; }
		public string Contact_Number { get; set; }
	}
}
