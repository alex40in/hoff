using System;

namespace Hoff.Domain.Entity.CbRf
{
    public class ValuteCursEntity
    {
        public ValuteCursEntity(int valuteId, decimal quantity, decimal curs, DateTime date) =>
            (ValuteId, Quantity, Curs, Date) = (valuteId, quantity, curs, date);

        public int ValuteId { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Curs { get; private set; }
        public DateTime Date { get; private set; }

    }
}
