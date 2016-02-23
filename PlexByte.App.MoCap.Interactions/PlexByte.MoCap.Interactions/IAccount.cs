//////////////////////////////////////////////////////////////
//                      Interface Account                              
//      Author: Fabian Ochsner            Date:   2016/02/19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IAccount
{
    List<IExpense> ExpenseList { get;  }

    List<ITimeslice> TimesliceList { get;  }

    void AddExpense(IExpense pExpense);

    void AddTimeslice(ITimeslice pTimeslice);

    void EditExpense(IExpense pExpense, IExpense pNewExpense);

    void DeleteExpense(IExpense pExpense);

    void EditTimeslice(ITimeslice pTimeslice, ITimeslice pNewTimeslice);

    void DeleteTimeslice(ITimeslice pTimeslice);
}

