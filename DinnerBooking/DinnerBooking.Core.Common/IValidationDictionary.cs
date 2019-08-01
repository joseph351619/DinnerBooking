using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Common
{
    public interface IValidationDictionary
    {
        void AddGeneralError(string errorMessage);
        bool IsValid();
        bool Any();
    }
}
