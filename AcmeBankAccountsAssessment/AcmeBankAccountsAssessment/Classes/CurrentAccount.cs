using AcmeBankAccountsAssessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBankAccountsAssessment.Classes
{
	public class CurrentAccount: ICurrentAccounts
	{
		#region Members
		private int mID { get; set; }
		private string mCustomerNum { get; set; }
		private decimal mBalance { get; set; }
		private decimal mOverdraftLimit { get; set; }
		#endregion

		#region Get & Set for Members
		// WOULD NORNALLY GET THIS FROM DB THEN INCRIMENT WHEN CLASS IS NEW AND SAVED
		public int ID
		{
			get
			{
				return mID;
			}
			set
			{
				mID = value;
			}
		}

		public string CustomerNum
		{
			get
			{
				return mCustomerNum;
			}
			set
			{
				mCustomerNum = value;
			}
		}

		public decimal Balance
		{
			get
			{
				return mBalance;
			}
			set
			{
				mBalance = value;
			}
		}

		public decimal OverdraftLimit
		{
			get
			{
				return mOverdraftLimit;
			}
			set
			{
				mOverdraftLimit = value;
			}
		}
		#endregion

		public CurrentAccount()
		{

		}

		public CurrentAccount(CurrentAccount pAccount)
		{
			mID = pAccount.ID;
			mCustomerNum = pAccount.CustomerNum;
			mBalance = pAccount.Balance;
			mOverdraftLimit = pAccount.OverdraftLimit;
		}

		public CurrentAccount(int pCustomerNum, decimal pDepositAmount)
		{
			OpenCurrentAccount(pCustomerNum, pDepositAmount);
		}

		public void OpenCurrentAccount(int pCustomerNum, decimal pDepositAmount)
		{

		}

		public void Withdraw(decimal pWithdrawAmount)
		{
			Console.WriteLine("Balance = " + mBalance.ToString());
			Console.WriteLine("Withdraw amount = " + pWithdrawAmount.ToString());

			if (pWithdrawAmount > (mBalance + mOverdraftLimit))
			{
				Console.WriteLine("Withdraw amount can not be more then your balance and allowed overdraft limit, Please enter a new withdraw amount...");
				return;
			}

			if (pWithdrawAmount > mBalance)
			{
				decimal deductFromOverdraft = (pWithdrawAmount - mBalance);
				mBalance = 0;
				mOverdraftLimit -= deductFromOverdraft;
			}
			else
				mBalance -= pWithdrawAmount;

			Console.WriteLine("New Balance :" + mBalance.ToString());
			Console.WriteLine("New Overdraft :" + mOverdraftLimit.ToString());
		}

		public void Deposit(decimal pDepositAmount)
		{
			if (pDepositAmount <= 0)
			{
				Console.WriteLine("Deposit amount can not be less then or equals to 0, Please enter a new deposit amount...");
				return;
			}

			mBalance += pDepositAmount;
			Console.WriteLine("New Balance :" + mBalance.ToString());

			Console.Read();
		}
	}
}
