using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FetchContactsDemo.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(UserContactService))]
namespace FetchContactsDemo.iOS
{
	public class UserContactService : IUserContactService
	{
		private readonly Xamarin.Contacts.AddressBook _book;
		private static IEnumerable<MobileUserContact> _contacts;
		public UserContactService()
		{
			_book = new Xamarin.Contacts.AddressBook();
		}

		public List<MobileUserContact> FindContacts(string searchInContactsString)
		{
			var ResultContacts = new List<MobileUserContact>();

			foreach (var currentContact in _contacts)
			{
				// Running a basic String Contains() search through all the 
				// fields in each Contact in the list for the given search string
				if ((currentContact.Contact_FirstName != null && currentContact.Contact_FirstName.ToLower().Contains(searchInContactsString.ToLower())) ||
					(currentContact.Contact_LastName != null && currentContact.Contact_LastName.ToLower().Contains(searchInContactsString.ToLower())) ||
					(currentContact.Contact_EmailId != null && currentContact.Contact_EmailId.ToLower().Contains(searchInContactsString.ToLower())))
				{
					ResultContacts.Add(currentContact);
				}
			}

			return ResultContacts;
		}

		public async Task<IEnumerable<MobileUserContact>> GetAllContacts()
		{
			if (_contacts != null) return _contacts;


			var contacts = new List<MobileUserContact>();
			await _book.RequestPermission().ContinueWith(t =>
						{
							if (!t.Result)
							{
								Console.WriteLine("Sorry ! Permission was denied by user or manifest !");
								return;
							}
							foreach (var contact in _book.ToList())
							{
								var firstOrDefault = contact.Emails.FirstOrDefault();

								contacts.Add(new MobileUserContact()
								{
									Contact_FirstName = contact.FirstName +"===>"+ contact.LastName +"===>"+ contact.DisplayName,
									Contact_LastName = contact.LastName,
									Contact_DisplayName = contact.DisplayName,
									Contact_EmailId = firstOrDefault != null ? firstOrDefault.Address : String.Empty
								});
							}
						});

			_contacts = (from c in contacts orderby c.Contact_FirstName select c).ToList();

			return _contacts;
		}
	}
}
