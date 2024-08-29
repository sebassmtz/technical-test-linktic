

using TechnicalTest.Domain.Common.Entities;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Domain.Reserves.Entities
{
    public class Reserve : Entity
    {
    

        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public bool Active { get; private set; } = true;
        public User User { get; private set; }

        public Guid UserId { get; private set; }

        private Reserve()
        {
        }

        public Reserve(DateTime dateStart, DateTime dateEnd, string description, bool active, Guid userId)
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
            Description = description;
            Active = active;
            UserId = userId;
        }

        public static Reserve CreateReserve(DateTime dateStart, DateTime dateEnd, string description, bool active, Guid userId)
        {
            return new Reserve(dateStart, dateEnd, description, active, userId);
        }

    }
}
