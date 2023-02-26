using AcmeBankAccountsAssessment.Classes;
using AcmeBankAccountsAssessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBankAccountsAssessment
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Notes
			// Ive decided to split the 2 interfaces since in the real world these 2 accounts work entirely different
			// Just using a normal List of accounts that gets initialized when i new the class since we dont have to add/delete/update accounts. (Probably could have used json object, local caching etc.)
			#endregion

			doSavingsTests();
			doCurrentTests();
		}

		private static void doSavingsTests()
		{
			// NEW CLASS TO INITIALIZE MOCK DATA TO SET ACCOUNTS
			// ALTERNATIVES WAS READING FROM JSON FILE, LOCAL CACHING
			SystemDB.SystemDB.Savings savingsDB = new SystemDB.SystemDB.Savings();
			ISavingsAccount saveAcc = new SavingAccount(savingsDB.SavingsData[0]);

			#region Withdraw
			Console.WriteLine("Withdraw Cases----------------------------------");
			// WTIHDRAW SHOULD UPDATE BALANCE TO 4500
			saveAcc.Withdraw(500);
			Console.WriteLine("");

			// WTIHDRAW MORE THEN THE MINIMUM 1000 BALANCE SHOULD TELL YOU NOT ALLOWED
			saveAcc.Withdraw(4500);
			Console.WriteLine("");

			// WTIHDRAW SHOULD TELL YOU THAT YOU ARE NOT ALLOWED TO DO A 0 AMOUNT WITHDRAWAL
			saveAcc.Withdraw(0);
			Console.WriteLine("");
			#endregion

			#region Deposit
			Console.WriteLine("Deposit Cases----------------------------------");
			// DEPOSIT SHOULD TELL YOU THAT YOU ARE NOT ALLOWED TO DO A 0 AMOUNT WITHDRAWAL
			saveAcc.Deposit(0);
			Console.WriteLine("");

			// DEPOSIT SHOULD UPDATE BALANCE TO 5000
			saveAcc.Deposit(500);
			Console.WriteLine("");
			#endregion

			Console.Read();
		}
		private static void doCurrentTests()
		{
			// NEW CLASS TO INITIALIZE MOCK DATA TO SET ACCOUNTS
			// ALTERNATIVES WAS READING FROM JSON FILE, LOCAL CACHING
			SystemDB.SystemDB.Current currentDB = new SystemDB.SystemDB.Current();
			ICurrentAccounts currAcc = new CurrentAccount(currentDB.CurrentData[0]);

			#region Withdraw
			Console.WriteLine("Withdraw Cases----------------------------------");
			// WTIHDRAW SHOULD NOT BE ALLOWED AS THE AMOUNT IS MORE THEN THE BALANCEAND ALLOWED OVERDRAFT
			currAcc.Withdraw(12000);
			Console.WriteLine("");

			// WTIHDRAW WILL UPDATE BALANCE TO 0 AND OVERDRAFT TO 9000
			currAcc.Withdraw(2000);
			Console.WriteLine("");
			#endregion

			#region Deposit
			Console.WriteLine("Deposit Cases----------------------------------");
			// DEPOSIT SHOULD TELL YOU THAT YOU ARE NOT ALLOWED TO DO A 0 AMOUNT WITHDRAWAL
			currAcc.Deposit(5000);
			Console.WriteLine("");
			#endregion

			Console.Read();
		}
	}
}
