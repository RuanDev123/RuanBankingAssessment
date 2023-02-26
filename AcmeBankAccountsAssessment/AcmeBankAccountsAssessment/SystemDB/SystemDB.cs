using AcmeBankAccountsAssessment.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBankAccountsAssessment.SystemDB
{
	public class SystemDB
	{
		public class Savings
		{
			private List<SavingAccount> mSavingsData;

			public List<SavingAccount> SavingsData
			{
				get
				{
					return mSavingsData;
				}
				set
				{
					mSavingsData = value;
				}
			}

			// ADD MOCK DATA IN CUNSTRUCTOR
			public Savings()
			{
				mSavingsData = new List<SavingAccount>();
				InitSavingsMockData();
			}

			private void InitSavingsMockData()
			{
				mSavingsData.Add(new SavingAccount
				{
					ID = 1,
					CustomerNum = "1",
					Balance = 5000,
				});

				mSavingsData.Add(new SavingAccount
				{
					ID = 2,
					CustomerNum = "2",
					Balance = 5000,
				});
			}
		}

		public class Current
		{
			private List<CurrentAccount> mCurrentData;

			public List<CurrentAccount> CurrentData
			{
				get
				{
					return mCurrentData;
				}
				set
				{
					mCurrentData = value;
				}
			}

			// ADD MOCK DATA IN CUNSTRUCTOR
			public Current()
			{
				mCurrentData = new List<CurrentAccount>();
				InitCurrentMockData();
			}

			private void InitCurrentMockData()
			{
				mCurrentData.Add(new CurrentAccount
				{
					ID = 3,
					CustomerNum = "3",
					Balance = 1000,
					OverdraftLimit = 10000
				});

				mCurrentData.Add(new CurrentAccount
				{
					ID = 4,
					CustomerNum = "4",
					Balance = -5000,
					OverdraftLimit = 20000
				});
			}
		}
	}
}
