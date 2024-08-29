
using TechnicalTest.Domain.Common.Entities;
using TechnicalTest.Domain.Reserves.Entities;
using TechnicalTest.Domain.Services.Entities;

namespace TechnicalTest.Domain.ReseveService.Entities
{
    public class ReserveService: Entity
    {
        public int Quantity { get; private set; }
        public DateTime Date { get; private set; }
        public Service Service { get; private set; }
        public Guid ServiceId { get; private set; }
        public Reserve Reserve { get; private set; }
        public Guid ReserveId { get; private set; }

        private ReserveService()
        {
        }

        public ReserveService(int quantity, DateTime date, Guid serviceId, Guid reserveId)
        {
            Quantity = quantity;
            Date = date;
            ServiceId = serviceId;
            ReserveId = reserveId;
        }

        public static ReserveService Create(int quantity, DateTime date, Guid serviceId, Guid reserveId)
        {
            return new ReserveService(quantity, date, serviceId, reserveId);
        }
    }
}
