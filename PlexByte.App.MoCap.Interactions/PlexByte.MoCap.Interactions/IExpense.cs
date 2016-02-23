//////////////////////////////////////////////////////////////
//                      Interface Expense                              
//      Author: Fabian Ochsner            Date:   2016/02/22
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

public interface IExpense
{
    decimal Value { get; }

    Image Receipt { get; }

    IInteraction Target { get; set; }

    void AddReceipt(Image pImage);

    void DeleteReceipt(Image pImage);

    void EditValue(decimal pNewValue);

}

