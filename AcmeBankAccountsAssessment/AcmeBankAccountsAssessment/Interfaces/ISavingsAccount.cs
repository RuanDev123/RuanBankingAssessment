using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBankAccountsAssessment.Interfaces
{
	interface ISavingsAccount
	{
		void OpenSavingsAccount(String pCustomerNum, decimal pDepositAmount);
		void Withdraw(decimal pWithdrawAmount);
		void Deposit(decimal pDepositAmount);
	}
}
