//////////////////////////////////////////////////////////////
//                      Interface Expense                              
//      Author: Fabian Ochsner            Date:   2016/02/22
using System.Drawing;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Interactions
{
    public interface IExpense
    {
        decimal Value { get; }

        System.Drawing.Image Receipt { get; }

        IInteraction Target { get; }

        IUser User { get; }

        void AddReceipt(Image pReceipt);

        void DeleteReceipt();

        void EditValue(decimal pNewValue);

    }

}