using AcmeBankAccountsAssessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBankAccountsAssessment.Classes
{
	public class SavingAccount: ISavingsAccount
	{
		#region Members
		private int mID { get; set; }
		private string mCustomerNum { get; set; }
		private decimal mBalance { get; set; }
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
		#endregion

		public SavingAccount()
		{
			
		}

		public SavingAccount(SavingAccount pAccount)
		{
			mID = pAccount.ID;
			mCustomerNum = pAccount.CustomerNum;
			mBalance = pAccount.Balance;
		}

		// CAN CREATE A NEW ACCOUNT IN CUNSTRUCTOR WHEN NEW'ING CLASS
		public SavingAccount(string pCustomerNum, decimal pDepositAmount)
		{
			OpenSavingsAccount(pCustomerNum, pDepositAmount);
		}

		public void OpenSavingsAccount(string pCustomerNum, decimal pDepositAmount)
		{
			if (pDepositAmount < 1000)
				Console.WriteLine("Opening balance cant be less then 1000");

			mBalance = pDepositAmount;
			mCustomerNum = pCustomerNum;

		}

		public void Withdraw(decimal pWithdrawAmount)
		{
			Console.WriteLine("Balance = " + mBalance.ToString());
			Console.WriteLine("Withdraw amount = " + pWithdrawAmount.ToString());

			if (pWithdrawAmount <= 0)
			{
				Console.WriteLine("Withdraw amount can not be less then or equals to 0, Please enter a new withdraw amount...");
				return;
			}

			if ((mBalance - pWithdrawAmount) < 1000)
			{
				Console.WriteLine("Account balance will be " + (mBalance - pWithdrawAmount).ToString() + " which is less then the 1000 minimum balance allowed");
				return;
			}

			mBalance -= pWithdrawAmount;
			Console.WriteLine("New Balance :" + mBalance.ToString());
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
