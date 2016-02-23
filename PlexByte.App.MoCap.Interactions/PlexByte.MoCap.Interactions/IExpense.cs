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
    decimal value { get;  }

    List<Image> ReceiptList { get;  }

    IInteraction Target { get; set; }

    List<decimal> ValueList { get; }

    void AddReceipt(Image pImage, decimal pValue);

    void DeleteReceipt(Image pImage, decimal pValue);

    void EditReceipt(Image pImage, Image pNewImage, decimal pValue, decimal pNewValue);

}

