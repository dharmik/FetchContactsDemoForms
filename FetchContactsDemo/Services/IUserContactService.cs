using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FetchContactsDemo
{
	public interface IUserContactService
	{
		Task<IEnumerable<MobileUserContact>> GetAllContacts();
		List<MobileUserContact> FindContacts(string searchInContactsString);
	}
}
