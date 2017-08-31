using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FetchContactsDemo
{
	public class FetchContactsViewModel : BaseModel
	{
		#region fields
		IUserContactService _contactService = null;
		#endregion

		#region Properties
		private ObservableCollection<MobileUserContact> contactList;
		public ObservableCollection<MobileUserContact> ContactList
		{
			get { 
				return contactList; 
			}
			set { 
				contactList = value; OnPropertyChanged("ContactList"); 
			}
		}
		#endregion

		#region Command
		private Command fetchContactCommand;
		public Command FetchContactCommand
		{
			get
			{
				return fetchContactCommand ?? new Command((obj) =>
				{
					GetContacts();
				});
			}
		}
		#endregion

		#region methods
		public async Task GetContacts()
		{
			try
			{
				_contactService = DependencyService.Get<IUserContactService>();
				var contacts = await _contactService.GetAllContacts();
				ContactList = new ObservableCollection<MobileUserContact>(contacts);
			}
			catch (System.Exception ex)
			{

			}
		}
		#endregion
	}
}
