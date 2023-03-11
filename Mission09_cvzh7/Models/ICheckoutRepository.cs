using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_cvzh7.Models
{
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> Checkouts { get; }

        void saveCheckout(Checkout checkout);
    }
}
